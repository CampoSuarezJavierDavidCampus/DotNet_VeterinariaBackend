
using Api.Helpers;
using Core.Entities;
using Core.Enums;
using Core.Interfaces;
using Core.Models.Dtos;
using Domain.Interfaces.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
public class AuthController:BaseApiController{
    private readonly IUnitOfWork _UnitOfWork;
    private readonly ILogger<AuthController> _Logger;
    private readonly ITokenManager _TokenManager;
    

    public AuthController(
            IConfiguration conf, 
            IUnitOfWork unitOfWork,       
            IPasswordHasher<User> PasswordHasher,
            ILogger<AuthController> logger
    ){
        _Logger = logger;
        _UnitOfWork = unitOfWork;        
        _TokenManager = new TokenManager(PasswordHasher,conf);
    }
    
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> RegisterAsync(UserSignup model){        
        var user = _TokenManager.CreateUser(model);

        var existingUser = await _UnitOfWork.Users.GetUserByName(model.UserName!);
        if (existingUser != null){
            return BadRequest($"El usuario {model.UserName} ya se encuentra registrado.");
        }
        
        var defaultRol =  (await _UnitOfWork.Roles.GetRolByRoleName( Roles.Employee ))!;        
        try{
            user.Roles.Add(defaultRol);
            user.Id = Guid.NewGuid().ToString();
            _UnitOfWork.Users.Add(user);            
            await _UnitOfWork.SaveAsync();
            return Ok($"El usuario  {model.UserName} ha sido registrado exitosamente");

        }catch(Exception ex){
            _Logger.LogCritical($"Error: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError,"Some Wrong");
        }
        
    }

    [HttpPost("Token")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> GetTokenAsync(UserLoggin model){
        TokenResponse userData = new(){IsAuthenticated = false,};
 
        User? user = await _UnitOfWork.Users.GetUserByName(model.UserName!);
        
        //-Validate User
        if (user == null){//-Validar existencia            
            userData.Message = $"No existe ningún usuario con el userName {model.UserName}.";
            return BadRequest(userData);                    

        }else if(!_TokenManager.ValidatePassword(user, model.Password!)){//-Validar Credenciales

            userData.Message =  $"Credenciales incorrectas para el usuario {model.UserName}.";;
            return BadRequest(userData);
        }
        
        //-Create Response menssage
        userData.Message = "Ok";
        userData.IsAuthenticated = true;
        userData.UserName = user.UserName;
        userData.Email = user.Email!;
        userData.AccessToken = _TokenManager.CreateAccessToken(user);
        userData.RefreshToken = _TokenManager.CreateRefreshToken();

        //-Save changes
        user.AccessToken = userData.AccessToken;
        user.RefreshToken = userData.RefreshToken;

        _UnitOfWork.Users.Update(user);
        await _UnitOfWork.SaveAsync();

        //-Return response
        return Ok(userData);
    }

    [HttpPost("changeRol")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> ChangeRolAsync(AddRol model){
        User? user;
        try{
            string? token = HttpContext.Request.Headers["Authorization"].FirstOrDefault() ?? throw new Exception("Invalid Token");                            
            //-Obtener usuario                        
            user = await _UnitOfWork.Users.GetUserByName(model.UserName!);

            //-Valida usuario
            if (user == null){throw new Exception($"No existe el usuario.");}
            if(token != "Bearer " + user.AccessToken){throw new Exception($"Invalid Token.");}
        
        }catch (Exception ex){
            _Logger.LogError(ex.Message);

            return StatusCode(
                StatusCodes.Status500InternalServerError,
                "some Wrong"
            );
        }        
        //-Obtener rol solicitado
        Role? existingRol = await _UnitOfWork.Roles.GetRolByRoleName(model.RolName);
        if (existingRol == null){//-Validar rol
            return BadRequest($"Rol {model.RolName} agregado a la cuenta {user.UserName} de forma exitosa.");
        }
                
        //-Agregar nuevo rol
        if (user.Roles.Any(x => x.Name == existingRol.Name)){
            user.Roles.Add(existingRol);
            _UnitOfWork.Users.Update(user);
            await _UnitOfWork.SaveAsync();
        }

        //-Retornar respuesta
        return Ok($"Rol {model.RolName} agregado a la cuenta {user.UserName} de forma exitosa.");               
    }

    [HttpPost("refresh/{userName}")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> RefreshToken(string userName){        
        //-Obtener token
        string? token = HttpContext.Request.Headers["Authorization"].FirstOrDefault() ?? throw new Exception("Invalid Token");
        User? user = await _UnitOfWork.Users.GetUserByName(userName);

        if(user == null ){return BadRequest("User not found");}

        else if("Bearer " + user.RefreshToken != token){return BadRequest("refresh token invalid");}

        return Ok(new {
            userName = user.UserName,
            AccessToken = _TokenManager.CreateAccessToken(user),
            refreshToken = token
        });

    }
}