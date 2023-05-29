using AlumniProject.Data.Repostitory;
using AlumniProject.Dto;
using AlumniProject.Entity;
using System.Diagnostics;

namespace AlumniProject.Service.ServiceImp;

public class GradeService : IGradeService
{
    private readonly IGradeRepo repo;
    public GradeService(IGradeRepo repo)
    {
        this.repo = repo;
    }

    public async Task<int> CreateGrade(Grade grade)
    {
        var existGradeCode = await repo.FindOneByCondition(g => g.Code == grade.Code && g.SchoolId == grade.SchoolId);
        if(existGradeCode != null)
        {
            throw new Exception("Code is exist");
        }
        else
        {
            var existGradeTime =  await repo.FindOneByCondition(g=> g.StartYear == grade.StartYear && g.SchoolId == grade.SchoolId);
            if( existGradeTime != null)
            {
                throw new Exception("Grade is exist");
            }
            grade.CreatedAt = DateTime.Now;
            var gradeId = await repo.CreateAsync(grade);
            return gradeId;
        }
    }

    public async Task<int> DupplicateGrade(int id)
    {
        var grade = await GetGradeById(id);
        CheckGradeIsExisted(grade);
        Grade duplicatedGrade = new Grade()
        {
            Code = string.Empty,
            StartYear = grade.StartYear + 1,
            EndYear = grade.EndYear + 1,
            SchoolId = grade.SchoolId,
            CreatedAt = DateTime.Now,
        };


        var duplicatedGradeId = await repo.CreateAsync(duplicatedGrade);
        return duplicatedGradeId;
    }

    public async Task<Grade> GetGradeById(int id)
    {
        var grade = await repo.GetByIdAsync(id);
        if(grade == null)
        {
            throw new Exception("Grade not found with id: "+id);
        }
        return  grade;
    }

    public async Task<PagingResultDTO<Grade>> GetGradePagingResults(int pageNo, int pageSize,int schoolId)
    {
        var gradeList = await repo.GetAllByConditionAsync(pageNo, pageSize, s => s.SchoolId == schoolId);
        return gradeList;
    }

    public async Task<Grade> UpdateGrade(Grade updateGrade)
    {
        Grade existGrade = await repo.GetByIdAsync(updateGrade.Id);
        CheckGradeIsExisted(existGrade);
        existGrade.StartYear = updateGrade.StartYear;
        existGrade.EndYear = updateGrade.EndYear;
        existGrade.Code = updateGrade.Code;

        await repo.UpdateAsync(existGrade);
        return existGrade;
    }

    private async void CheckGradeIsExisted(Grade grade)
    {
        if (grade == null)
        {
            throw new Exception("Grade not found with id: " + grade.Id);
        }
        var existGradeTime = await repo.FindOneByCondition(g => g.StartYear == grade.StartYear && g.SchoolId == grade.SchoolId);
        if (existGradeTime != null)
        {
            throw new Exception("Grade is exist");
        }
        var existGradeCode = await repo.FindOneByCondition(g => g.Code == grade.Code && g.SchoolId == grade.SchoolId);
        if (existGradeCode != null)
        {
            throw new Exception("Code is exist");
        }
    }
}
