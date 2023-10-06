
# Desarrollo Backend NetCore Filtro Final

El proyecto de desarrollo de software tiene como objetivo principal la creación de un sistema de administración para una veterinaria. Este sistema permitirá a los administradores y al personal de la veterinaria gestionar de manera eficiente y efectiva todas las actividades relacionadas con la atención de mascotas y la gestión de clientes.




## Inicialización
- Requiere instalacion de [DotnetSdk](https://dotnet.microsoft.com/es-es/download) instalado 

- Requiere instalacion de [MySQL Workbench](https://www.mysql.com/downloads/)

- Requiere la instalacion de dotnet ef 
```bash
  dotnet tool install --g dotnet-ef 
```

### Clona el repositorio

```bash
  git clone https://github.com/CampoSuarezJavierDavidCampus/Veterinaria-Javier.git  
```

Procede a abrir la carpeta y se realiza la ejecucion de la base de datos
```bash
  C:\Users\APM01-45\Documents\Veterinaria-Javier> dotnet ef database update -p .\Infrastructure\ -s .\Api\
```

![DB](https://github.com/CampoSuarezJavierDavidCampus/Veterinaria-Javier/blob/main/Images/DB.png)


Ingresa en Api y ejecuta el servidor
```bash
  C:\Users\APM01-45\Documents\Veterinaria-Javier\Api> dotnet run
```
## Consultas Grupo A

#### Crear un consulta que permita visualizar los veterinarios cuya especialidad sea Cirujano vascular.

```http  
  Get api/Veterinarian/GetVeterinariansBySpecialty?Specialty=Cirujano%20vascular
```
| name | Type     | Description                |
| :-------- | :------- | :------------------------- |
| `Specialty` | `string` | **Required**. From query. |

#### Listar los medicamentos que pertenezcan a el laboratorio Genfar.

```http
  GET api/Medicine/FindMedicationsByLaboratory?laboratoryName=Genfar
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `laboratoryName`      | `string` | **Required**. From query |

#### Mostrar las mascotas que se encuentren registradas cuya especie sea felina.

```http
  GET api/Pet/GetPetsBySpecies?specie=felina
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `specie`      | `string` | **Required**. From query |

#### Listar los propietarios y sus mascotas.

```http
  GET api/Owner/GetOwnersWithPets
```

#### Listar los medicamentos que tenga un precio de venta mayor a 50000.

```http
  GET api/Medicine/GetBySalePrice?price=5000
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `price`      | `float` | **Required**. From query |

#### Listar las mascotas que fueron atendidas por motivo de vacunacion en el primer trimestre del 2023

```http
  GET api/Appointment/PetsCaredForByDateAndReason
  Body: {
    "InitialDate": "2017-04-04",
    "FinalDate": "2023-04-04",
    "Reason": "vacunacion"
  }
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `InitialDate`      | `DateTime` | **Required**. Fecha inicial, Formato yyyy-MM-dd |
| `FinalDate`      | `DateTime` | **Required**. Fecha Final, Formato yyyy-MM-dd |
| `Reason`      | `string` | **Required**. Motivo |

