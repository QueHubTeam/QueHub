using Microsoft.AspNetCore.Mvc;
using QueHub.Service.DTOs.Questions;
using QueHub.Service.Interfaces;
using QueHub.WebApi.controllers;

namespace QueHub.WebApi.Controllers;

public class QuestionController : BaseController
{
    private readonly IQuestionService _questionService;

    public QuestionController(IQuestionService questionService)
    {
        _questionService = questionService;
    }

    [HttpPost]
    public async Task<IActionResult> Create(QuestionCreationDto dto)
    {
        var createdQuestion = await _questionService.CreateAsync(dto);
        return Ok(createdQuestion);
    }

    [HttpPut]
    public async Task<IActionResult> Update(QuestionUpdateDto dto)
    {
        var updatedQuestion = await _questionService.UpdateAsync(dto);
        return Ok(updatedQuestion);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        var result = await _questionService.DeleteAsync(id);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        var question = await _questionService.GetByIdAsync(id);
        return Ok(question);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var questions = await _questionService.GetAllQAsync();
        return Ok(questions);
    }

    [HttpGet("user/{userId}")]
    public async Task<IActionResult> GetByUserId(long userId)
    {
        var questions = await _questionService.GetByUserIdAsync(userId);
        return Ok(questions);
    }

    [HttpGet("category/{categoryId}")]
    public async Task<IActionResult> GetByCategoryId(long categoryId)
    {
        var questions = await _questionService.GetByCategoryIdAsync(categoryId);
        return Ok(questions);
    }

    [HttpGet("search")]
    public async Task<IActionResult> Search(string searchTerm)
    {
        var questions = await _questionService.SearchAsync(searchTerm);
        return Ok(questions);
    }

    [HttpPatch("{id}/update-image")]
    public async Task<IActionResult> UpdateImage(long id, string imagePath)
    {
        var result = await _questionService.UpdateImageAsync(id, imagePath);
        return Ok(result);
    }
}