using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace Library.Controllers
{
    [Route("api/Library")]
    [ApiController]
    public class LibraryApiController : ControllerBase
    {
        LibraryContext _dbContext;
        public LibraryApiController (LibraryContext librayContext)
        {
            _dbContext = librayContext;
        }

        [HttpGet("BooksDetail")]
        public async Task<ActionResult> GetBooksDetail()
        {

            try
            {
                List<BookDetails> lstBooks = new List<BookDetails>();
                lstBooks = await _dbContext.BookDetails.Include(b => b.AuthorDetail)
                    .Include(b => b.SubCategoryDetail).ThenInclude( c => c.CategoryDetail).ToListAsync();
                return StatusCode((int)HttpStatusCode.OK, lstBooks);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("BooksDetail/{id}")]
        public async Task<ActionResult> GetBooksDetail(int id)
        {

            try
            {
                List<BookDetails> lstBooks = new List<BookDetails>();
                lstBooks = await _dbContext.BookDetails.Where(b => b.BookId == id).Include(b => b.AuthorDetail)
                    .Include(b => b.SubCategoryDetail).ThenInclude(c => c.CategoryDetail).ToListAsync();
                return StatusCode((int)HttpStatusCode.OK, lstBooks);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("BooksDetail/SubCategory/{id}")]
        public async Task<ActionResult> GetBooksDetailBySubCategory(int id)
        {

            try
            {
                List<BookDetails> lstBooks = new List<BookDetails>();
                lstBooks = await _dbContext.BookDetails.Where(b => b.SubCategoryId == id).Include(b => b.AuthorDetail)
                    .Include(b => b.SubCategoryDetail).ThenInclude(c => c.CategoryDetail).ToListAsync();
                return StatusCode((int)HttpStatusCode.OK, lstBooks);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("Categories")]
        public async Task<ActionResult> GetCategories()
        {

            try
            {
                List<Categories> lstCategories = new List<Categories>();
                lstCategories = await _dbContext.Categories.ToListAsync();
                return StatusCode((int)HttpStatusCode.OK, lstCategories);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("SubCategories")]
        public async Task<ActionResult> GetSubCategories()
        {

            try
            {
                List<SubCategories> lstSubCat = new List<SubCategories>();
                lstSubCat = await _dbContext.SubCategories.Include(c => c.CategoryDetail).ToListAsync();
                return StatusCode((int)HttpStatusCode.OK, lstSubCat);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpGet("Author")]
        public async Task<ActionResult> GetAuthors()
        {

            try
            {
                List<Authors> lstAuthor = new List<Authors>();
                lstAuthor = await _dbContext.Authors.ToListAsync();
                return StatusCode((int)HttpStatusCode.OK, lstAuthor);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, ex.Message);
            }
        }

    }
}
