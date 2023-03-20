﻿using Microsoft.EntityFrameworkCore;
using PA_Course_Submission.Contexts;
using PA_Course_Submission.Models;
using PA_Course_Submission.Models.Entities;


namespace PA_Course_Submission;

internal class CaseService
{
    public static DataContext _context = new DataContext();

    public static async Task<CaseEntity> SaveAsync(AddCase addCase)
    {
        var _caseEntity = new CaseEntity
        {
            Title       = addCase.Title,
            Description = addCase.Description,
            CustomerID  = addCase.CustomerId,
            Status      = addCase.Status,
        };

        _context.Add(_caseEntity);
        await _context.SaveChangesAsync();
        return _caseEntity;
    }

    public static async Task<IEnumerable<Case>> GetAllAsync()
    {
                var _cases  = new List<Case>();

        foreach (var _case in await _context.Cases.ToListAsync())
            _cases.Add(new Case
            {
                Id          = _case.Id,
                Title       = _case.Title,
                Description = _case.Description,
                Status      = _case.Status,
                Comment     = _case.Comment,
                CustomerId  = _case.CustomerID,
            });

            return _cases;
    }

    public static async Task<Case> GetAsync(int customerId)
    {
                var _case = await _context.Cases.Include(x => x.Customer).FirstOrDefaultAsync(x => x.CustomerID == customerId);
        if (_case != null)
            return new Case
            {
                Id          = _case.Id,
                Description = _case.Description,
                Title       = _case.Title,
                Status      = _case.Status,
                Comment     = _case.Comment,
                CustomerId  = _case.CustomerID,
            };
        else
            return null!;
    }
/*
    public static async Task<Case> UpdateCaseStatus(int caseId)
    {

        var _case = await _context.Cases.FirstOrDefaultAsync(x => x.Id == caseId);
        if (_case != null)
            return new Case
            {
                Id = _case.Id,
                Status = _case.Status
            };
        else
            

        _context.Add(_caseEntity);
        await _context.SaveChangesAsync();
        return _caseEntity;
    }
*/
}