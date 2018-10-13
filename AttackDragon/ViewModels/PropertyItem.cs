﻿using AttackDragon.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AttackDragon.ViewModels
{
    public class PropertyItem
    {
        public ImageSource ImageSource { get; set; }

        private string GenericSignatre => (MethodInfo.IsGenericMethod) ? $"<{string.Join(", ", MethodInfo.GetGenericArguments().Select(c => c.Name))}>" : "";

        private string MethodSignature => (ItemType == ItemType.Method) ? $"({string.Join(", ", MethodInfo.GetParameters().Select(c => c.ParameterType))})" : "";

        public string Name => $"{MethodInfo.Name}{GenericSignatre}{MethodSignature}";

        public string StandardName => Name.MethodStandardName();

        public MethodInfo MethodInfo { get; set; }

        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Method, Event, Property
    }
}
