using LibraryManager.Data.Models;
using LibraryManager.Data.Repositories.SubjectRepositories;

namespace LibraryManager.Data.Services.SubjectService;

public class SubjectService : ISubjectService
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectService(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    public async Task<ServiceResponse<List<Subject>>> GetAllAsync()
    {
        var response = new ServiceResponse<List<Subject>>();

        if (await _subjectRepository.GetAll() is { } subjects)
        {
            response.Data = subjects.ToList();
            response.Message = "Subjects found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Subjects not found";
        }

        return response;

    }

    public async Task<ServiceResponse<Subject>> GetByIdAsync(int id)
    {
        var response = new ServiceResponse<Subject>();
        
        if (await _subjectRepository.GetById(id) is { } subject)
        {
            response.Data = subject;
            response.Message = "Subject found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Subject not found";
        }

        return response;
    }

    public async Task<ServiceResponse<Subject>> GetByNameAsync(string name)
    {
        var response = new ServiceResponse<Subject>();
        
        if (await _subjectRepository.GetByName(name) is { } subject)
        {
            response.Data = subject;
            response.Message = "Subject found";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Subject not found";
        }
        
        return response;
    }

    public async Task<ServiceResponse<Subject>> CreateAsync(Subject subject)
    {
        var response = new ServiceResponse<Subject>();

        if (await _subjectRepository.Create(subject) > 0)
        {
            response.Data = subject;
            response.Message = "Subject created successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to create subject";
        }

        return response;
    }

    public async Task<ServiceResponse<Subject>> UpdateAsync(Subject subject)
    {
        var response = new ServiceResponse<Subject>();

        if (await _subjectRepository.Update(subject) > 0)
        {
            response.Data = subject;
            response.Message = "Subject updated successfully";
            response.Success = true;
        }
        else
        {
            response.Success = false;
            response.Message = "Failed to update subject";
        }

        return response;
    }

    public async Task<ServiceResponse<bool>> DeleteAsync(int id)
    {
        var serviceResponse = new ServiceResponse<bool>();

        if (await _subjectRepository.Delete(id) > 0)
        {
            serviceResponse.Data = true;
            serviceResponse.Message = "Subject deleted successfully";
            serviceResponse.Success = true;
        }
        else
        {
            serviceResponse.Success = false;
            serviceResponse.Message = "Failed to delete subject";
        }

        return serviceResponse;
    }
}