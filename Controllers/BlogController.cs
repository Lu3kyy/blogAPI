using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blogAPI.Models;
using blogAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace blogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly BlogItemService _data;

        public BlogController(BlogItemService dataFromService)
        {
            _data = dataFromService;
        }


        [HttpPost("AddBlogItems")]
        public bool AddBlogItems(BlogItemModel newBlogItem)
        {
            return _data.AddBlogItems(newBlogItem);
        }



        //get blog items
        [HttpGet("GetBlogItems")]
        public IEnumerable<BlogItemModel> GetAllBlogItems()
        {
            return _data.GetAllBlogItems();
        }

        //Get Items By Catagory 

        [HttpGet("GetBlogItemsByCategory/{category}")]
        public IEnumerable<BlogItemModel>GetItems(string category)
        {
            return _data.GetItemsByCategory(category);
        }


        //items by tag
        [HttpGet("GetBlogItemsByTag/{tag}")]
        public List<BlogItemModel> GetItemsByTag(string tag)
        {
            return _data.GetItemsByTag(tag);
        }

    // GetBlogItemsByDate
        [HttpGet("GetBlogItemsByDate/{date}")]
        public IEnumerable<BlogItemModel> GetItemsByDate(string date)
        {
            return _data.GetItemsByDate(date);
        }

    // GetPublishedBlogItems
        [HttpGet("GetPublishedItems")]
        public IEnumerable<BlogItemModel> GetPublishedItems()
        {
            return _data.GetPublishedItems();
        }

    // UpdateBlogItems
            [HttpPut("blogUpdate")]
            public bool UpdateBlogItems(BlogItemModel blogUpdate)
            {
                return _data.UpdateBlogItems(blogUpdate);
            }

    // DeleteBlogItems
            [HttpDelete("DeleteBlogItem/{BlogToDelete}")]
            public bool DeleteBlogItem(BlogItemModel BlogToDelete)
            {
                return _data.DeleteBlogItems(BlogToDelete);
            }


    // GetUserById


    }
}