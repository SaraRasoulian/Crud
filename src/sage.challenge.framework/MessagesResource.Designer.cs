﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace sage.challenge.framework {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MessagesResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MessagesResource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("sage.challenge.framework.MessagesResource", typeof(MessagesResource).Assembly);
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
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to That email address is already in use, please use a different email address..
        /// </summary>
        public static string DuplicateEmail {
            get {
                return ResourceManager.GetString("DuplicateEmail", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must be 18 years old or above..
        /// </summary>
        public static string NotValidAge {
            get {
                return ResourceManager.GetString("NotValidAge", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Sorry, something went wrong..
        /// </summary>
        public static string Status500 {
            get {
                return ResourceManager.GetString("Status500", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User ID is incorrect, please try again. .
        /// </summary>
        public static string UserIdMismatch {
            get {
                return ResourceManager.GetString("UserIdMismatch", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to User not found..
        /// </summary>
        public static string UserNotFound {
            get {
                return ResourceManager.GetString("UserNotFound", resourceCulture);
            }
        }
    }
}