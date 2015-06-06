// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Match> ToMatches(this IEnumerable<MatchItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Select(f => f.Match);
        }

        public static IEnumerable<Match> ToMatches(this IEnumerable<ReplaceItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Select(f => f.Match);
        }

        public static IEnumerable<Group> ToGroups(this IEnumerable<MatchItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToGroupItems().ToGroups();
        }

        public static IEnumerable<Group> ToGroups(this IEnumerable<GroupItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Select(f => f.Group);
        }

        public static IEnumerable<GroupInfo> ToGroupInfos(this IEnumerable<GroupItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Select(f => f.GroupInfo);
        }

        public static IEnumerable<Capture> ToCaptures(this IEnumerable<MatchItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToGroupItems().ToCaptures();
        }

        public static IEnumerable<Capture> ToCaptures(this IEnumerable<GroupItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToCaptureItems().ToCaptures();
        }

        public static IEnumerable<Capture> ToCaptures(this IEnumerable<CaptureItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Select(f => f.Capture);
        }

        public static IEnumerable<GroupItem> ToGroupItems(this IEnumerable<MatchItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.SelectMany(f => f.GroupItems);
        }

        public static IEnumerable<GroupItem> ToGroupItems(this IEnumerable<MatchItem> items, int groupIndex)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToGroupItems(f => f.GroupInfo.Index == groupIndex);
        }

        public static IEnumerable<GroupItem> ToGroupItems(this IEnumerable<MatchItem> items, string groupName)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToGroupItems(f => f.Name == groupName);
        }

        public static IEnumerable<GroupItem> ToGroupItems(this IEnumerable<MatchItem> items, bool successOnly)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return successOnly ? items.ToGroupItems(f => f.Success) : items.ToGroupItems();
        }

        internal static IEnumerable<GroupItem> ToGroupItems(this IEnumerable<MatchItem> items, Func<GroupItem, bool> predicate)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToGroupItems().Where(predicate);
        }

        public static IEnumerable<CaptureItem> ToCaptureItems(this IEnumerable<MatchItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.ToGroupItems().ToCaptureItems();
        }

        public static IEnumerable<CaptureItem> ToCaptureItems(this IEnumerable<GroupItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.SelectMany(f => f.CaptureItems);
        }

        public static IEnumerable<ReplaceResult> ToResults(this IEnumerable<ReplaceItem> items)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            return items.Select(f => f.Result);
        }

        public static IEnumerable<string> ToNames(this IEnumerable<GroupInfo> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            return collection.Select(f => f.Name);
        }

        public static IEnumerable<int> ToIndexes(this IEnumerable<GroupInfo> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            return collection.Select(f => f.Index);
        }

        public static IEnumerable<GroupInfo> ExceptZero(this IEnumerable<GroupInfo> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            return collection.Where(f => f.Index != 0);
        }

        internal static IEnumerable<GroupItem> FilterAndSort(this GroupItemCollection items, GroupSettings settings)
        {
            if (items == null)
            {
                throw new ArgumentNullException("items");
            }

            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            return items
                .Where(f => !settings.IsIgnored(f.Name))
                .OrderBy(f => f.GroupInfo, settings.Sorter);
        }
    }
}
