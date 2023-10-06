using AutoMapper;
using Core.Entities;
using Core.Models.Dtos;

namespace Api.Profiles;
public class MappingProfiles: Profile{
    public MappingProfiles(){        /* OwnerWithPets */
        CreateMap<Owner,OwnerWithPets>().ReverseMap();
        CreateMap<Appointment,AppointmentDto>().ReverseMap();
        CreateMap<Breed,BreedDto>().ReverseMap();
        CreateMap<Kind,KindDto>().ReverseMap();
        CreateMap<Laboratory,LaboratoryDto>().ReverseMap();        
        CreateMap<MedicalTreatment,MedicalTreatmentDto>().ReverseMap();
        CreateMap<Medicine,MedicineDto>().ReverseMap();
        CreateMap<MovementMedicine,MovementMedicineDto>().ReverseMap();
        CreateMap<MovementMedicineDetail,MovementMedicineDetailDto>().ReverseMap();
        CreateMap<MovementType,MovementTypeDto>().ReverseMap();
        CreateMap<Owner,OwnerDto>().ReverseMap();
        CreateMap<Pet,PetDto>().ReverseMap();
        CreateMap<Role,RoleDto>().ReverseMap();
        CreateMap<Supplier,SupplierDto>().ReverseMap();
        CreateMap<User,UserDto>().ReverseMap();
        CreateMap<Veterinarian,VeterinarianDto>().ReverseMap();
    }
}
