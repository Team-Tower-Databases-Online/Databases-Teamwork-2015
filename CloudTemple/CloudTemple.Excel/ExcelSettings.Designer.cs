﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CloudTemple.Excel {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class ExcelSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static ExcelSettings defaultInstance = ((ExcelSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new ExcelSettings())));
        
        public static ExcelSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\'Excel 12.0" +
            " xml;HDR=Yes\';")]
        public string ExcelConnectionString {
            get {
                return ((string)(this["ExcelConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\ModelsData\\models-data.xlsx")]
        public string ModelsDataFileLocation {
            get {
                return ((string)(this["ModelsDataFileLocation"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\ModelsData\\SalesReports\\")]
        public string SalesReportsDestinationFolder {
            get {
                return ((string)(this["SalesReportsDestinationFolder"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\DataSources\\sales-reports.zip")]
        public string OutputZipFileLocation {
            get {
                return ((string)(this["OutputZipFileLocation"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("..\\..\\..\\..\\Reports\\XlsxReports\\")]
        public string ExcelReportsDestinationFolder {
            get {
                return ((string)(this["ExcelReportsDestinationFolder"]));
            }
        }
    }
}
