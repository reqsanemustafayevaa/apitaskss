﻿using BookStoreApi.Data;
using BookStoreApi.DTOs;
using BookStoreApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoriesController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("")]
        public IActionResult GetAll()
        {
            List<Book> books = new List<Book>();
            List<CategoryGetDto> categorydtos = new List<CategoryGetDto>();
            foreach (var item in categorydtos)
            {
                CategoryGetDto categorydto = new CategoryGetDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    
                };
                categorydtos.Add(categorydto);
            }
            return Ok(categorydtos);
        }
        [HttpGet("{id}")]
        public IActionResult GetAction(int id)
        {


            var book = _context.Categories.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            CategoryGetDto dto = new CategoryGetDto()
            {
                Id = book.Id,
                Name = book.Name,
                
            };
            return Ok(book);
        }
        [HttpPost]
        
        public IActionResult Create(CategoryCreateDto dto)
        {
            Category category = new Category()
            {
                Name = dto.Name,
               
            };
            category.CreatedDate = DateTime.UtcNow.AddHours(4);
            category.UpdateDate = DateTime.UtcNow.AddHours(4);
            category.IsDeleted = false;
            _context.Categories.Add(category);
            _context.SaveChanges();
            return StatusCode(201, new { message = "object yaradildi" });
        }
    }
}
