﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace EMap.Gis.Symbology
{
    public static class MemberInfoExtensions
    {
        #region Methods

        /// <summary>
        /// Determines whether there is a member with the specified name.
        /// </summary>
        /// <param name="self">this</param>
        /// <param name="name">Name of the item to search for.</param>
        /// <returns>True, if a MemberInfo with the specified name exists.</returns>
        public static bool Contains(this IEnumerable<MemberInfo> self, string name)
        {
            return self.Any(info => info.Name == name);
        }

        /// <summary>
        /// Gets the first member in the enumerable collection of property info with the specified name.
        /// </summary>
        /// <typeparam name="T">Type of the items in the enumerable.</typeparam>
        /// <param name="self">this</param>
        /// <param name="name">Name of the item to search for.</param>
        /// <returns>The first item with the given name.</returns>
        public static T GetFirst<T>(this IEnumerable<T> self, string name)
            where T : MemberInfo
        {
            Func<T, bool> criteria = current => (current.Name == name);
            return self.FirstOrDefault(criteria);
        }

        #endregion
    }
}
