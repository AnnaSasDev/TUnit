﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TUnit.Analyzers {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
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
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("TUnit.Analyzers.Resources", typeof(Resources).Assembly);
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
        ///   Looks up a localized string similar to Replace &apos;{0}&apos; with &apos;{1}&apos;.
        /// </summary>
        internal static string TUnit0001CodeFixTitle {
            get {
                return ResourceManager.GetString("TUnit0001CodeFixTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type names should not contain the company name..
        /// </summary>
        internal static string TUnit0001Description {
            get {
                return ResourceManager.GetString("TUnit0001Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type name &apos;{0}&apos; contains the company name.
        /// </summary>
        internal static string TUnit0001MessageFormat {
            get {
                return ResourceManager.GetString("TUnit0001MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type name contains the company name.
        /// </summary>
        internal static string TUnit0001Title {
            get {
                return ResourceManager.GetString("TUnit0001Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The speed must be lower than the Speed of Light..
        /// </summary>
        internal static string TUnit0002Description {
            get {
                return ResourceManager.GetString("TUnit0002Description", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The specified speed &apos;{0}&apos; must be lower than the Speed of Light.
        /// </summary>
        internal static string TUnit0002MessageFormat {
            get {
                return ResourceManager.GetString("TUnit0002MessageFormat", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The impossible speed.
        /// </summary>
        internal static string TUnit0002Title {
            get {
                return ResourceManager.GetString("TUnit0002Title", resourceCulture);
            }
        }
    }
}
