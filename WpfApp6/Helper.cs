﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AttachedProperties

{
    public static class Helper
    {
        public static Style GetAdditionalStyle(DependencyObject dObj)
        {
            return (Style)dObj.GetValue(AdditionalStyleProperty);
        }

        public static void SetAdditionalStyle(DependencyObject dObj, Style value)
        {
            dObj.SetValue(AdditionalStyleProperty, value);
        }

        // Using a DependencyProperty as the backing store for PlaceholderStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdditionalStyleProperty =
                DependencyProperty.RegisterAttached(nameof(GetAdditionalStyle)[3..], typeof(Style), typeof(Helper), new PropertyMetadata(null));
    }
}
