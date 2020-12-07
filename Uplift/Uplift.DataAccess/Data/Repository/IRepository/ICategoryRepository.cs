﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;
using Uplift.Models;

namespace Uplift.DataAccess.Data.Repository.IRepository
{
    interface ICategoryRepository : IRepository<Category>
    {
        IEnumerable<SelectListItem> GetCategoryListForDropDown();

        void Update(Category category);
    }
}
