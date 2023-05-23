﻿/*
' Copyright (c) 2023 kristof pinter
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Common.Utilities;
using DotNetNuke.ComponentModel.DataAnnotations;
using DotNetNuke.Entities.Content;
using System;
using System.Web.Caching;

namespace GMKN.Dnn.map_modul.Models
{
    [TableName("map_modul_Items")]
    //setup the primary key for table
    [PrimaryKey("ItemId", AutoIncrement = true)]
    //configure caching using PetaPoco
    [Cacheable("Items", CacheItemPriority.Default, 20)]
    //scope the objects to the ModuleId of a module on a page (or copy of a module on a page)
    [Scope("ModuleId")]
    public class Item
    {
        
        public int ItemId { get; set; } = -1;
      
        public string ItemName { get; set; }

      
        public string ItemDescription { get; set; }

        
        public int AssignedUserId { get; set; }

      
        public int ModuleId { get; set; }

        public string MapLink { get; set; }

       
        public int CreatedByUserId { get; set; } = -1;

        public int LastModifiedByUserId { get; set; } = -1;

       
        public DateTime CreatedOnDate { get; set; } = DateTime.UtcNow;

        public DateTime LastModifiedOnDate { get; set; } = DateTime.UtcNow;
    }
}