﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MooVC.Architecture {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MooVC.Architecture.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The maximum supported ID of {0} for entity of type {1} has been exceeded..
        /// </summary>
        internal static string EntityMaximumIdValueExceededExceptionMessage {
            get {
                return ResourceManager.GetString("EntityMaximumIdValueExceededExceptionMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type of the entity must be provided..
        /// </summary>
        internal static string EntityMaximumIdValueExceededExceptionTypeRequired {
            get {
                return ResourceManager.GetString("EntityMaximumIdValueExceededExceptionTypeRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The context of the message must be provided..
        /// </summary>
        internal static string MessageContextRequired {
            get {
                return ResourceManager.GetString("MessageContextRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The message that serves as the context for coordination must be provided..
        /// </summary>
        internal static string MessageExtensionsCoordinateMessageRequired {
            get {
                return ResourceManager.GetString("MessageExtensionsCoordinateMessageRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The object that serves as the context for coordination must be provided..
        /// </summary>
        internal static string ObjectExtensionsCoordinateObjectRequired {
            get {
                return ResourceManager.GetString("ObjectExtensionsCoordinateObjectRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The context of the request must be provided..
        /// </summary>
        internal static string RequestContextRequired {
            get {
                return ResourceManager.GetString("RequestContextRequired", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The type that serves as the context for coordination must be provided..
        /// </summary>
        internal static string TypeExtensionsCoordinateTypeRequired {
            get {
                return ResourceManager.GetString("TypeExtensionsCoordinateTypeRequired", resourceCulture);
            }
        }
    }
}
