﻿using CRM.Services.Customers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileAheresisAdmin.Utils
{
    public static class SelectListHelper
    {

        /// <summary>
        /// Convert to select list
        /// </summary>
        /// <typeparam name="TEnum">Enum type</typeparam>
        /// <param name="enumObj">Enum</param>
        /// <param name="markCurrentAsSelected">Mark current value as selected</param>
        /// <param name="valuesToExclude">Values to exclude</param>
        /// <param name="useLocalization">Localize</param>
        /// <returns>SelectList</returns>
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj,
           bool markCurrentAsSelected = true, int[] valuesToExclude = null, bool useLocalization = true) where TEnum : struct
        {
            if (!typeof(TEnum).IsEnum) throw new ArgumentException("An Enumeration type is required.", "enumObj");



            var values = from TEnum enumValue in Enum.GetValues(typeof(TEnum))
                         where valuesToExclude == null || !valuesToExclude.Contains(Convert.ToInt32(enumValue))
                         select new { ID = Convert.ToInt32(enumValue), Name = useLocalization ? enumValue.ToString() : CommonHelper.ConvertEnum(enumValue.ToString()) };
            object selectedValue = null;
            if (markCurrentAsSelected)
                selectedValue = Convert.ToInt32(enumObj);
            return new SelectList(values, "ID", "Name", selectedValue);
        }


        public static List<SelectListItem> GetPageSizeDropdown(string SelectedValue = null)
        {
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            selectListItems.Add(new SelectListItem { Text = "50", Value = "50", Selected = (SelectedValue == "50") });
            selectListItems.Add(new SelectListItem { Text = "100", Value = "100", Selected = (SelectedValue == "100") });
            selectListItems.Add(new SelectListItem { Text = "200", Value = "200", Selected = (SelectedValue == "200") });
            selectListItems.Add(new SelectListItem { Text = "All", Value = "0", Selected = (SelectedValue == "0") });
            return selectListItems;
        }

    }
}
