using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows;

namespace ToratEmet.Models
{
    public static class FindParentOrChild
    {
        public static T TryFindParent<T>(DependencyObject current) where T : class
        {
            DependencyObject parent = VisualTreeHelper.GetParent(current);
            if (parent == null)
                parent = LogicalTreeHelper.GetParent(current);
            if (parent == null)
                return null;

            if (parent is T)
                return parent as T;
            else
                return TryFindParent<T>(parent);
        }

        public static childItem FindVisualChild<childItem>(DependencyObject obj)
        where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                {
                    return (childItem)child;
                }
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }


        //public static void GetLogicalChildren<T>(DependencyObject parent, List<T> logicalCollection) where T : DependencyObject
        //{
        //    IEnumerable children = LogicalTreeHelper.GetChildren(parent);

        //    foreach (object child in children)
        //    {
        //        if (child is DependencyObject)
        //        {
        //            DependencyObject depChild = child as DependencyObject;

        //            if (child is T)
        //            {
        //                logicalCollection.Add(child as T);
        //            }

        //            GetLogicalChildren(depChild, logicalCollection);
        //        }
        //    }
        //}
    }
}

