//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Count4U.Service.Format.Xml
//{

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
//    public partial class Profile
//    {

//        private ProfileInventoryProcessInformation inventoryProcessInformationField;

//        private ProfileInventoryProcessConfiguration inventoryProcessConfigurationField;

//        private string scannerTypeField;

//        private ProfileLocationInventoryListScreenConfiguration locationInventoryListScreenConfigurationField;

//        private ProfileInventoryListDefaultUIConfiguration inventoryListDefaultUIConfigurationField;

//        private ProfileDatabaseSettings databaseSettingsField;

//        private ProfileForms formsField;

//        private ProfileSearch searchField;

//        private ProfileScreensConfiguration screensConfigurationField;

//        private ProfileInventoryImage inventoryImageField;

//        private ProfilePrinterSettings printerSettingsField;

//        private ProfileRFID rFIDField;

//        private ProfileFastStockInventoryItemsConfiguration fastStockInventoryItemsConfigurationField;

//        private object barcodeManipulationsField;

//        private byte versionField;

//        private ProfileCustomer customerField;

//        /// <remarks/>
//        public ProfileInventoryProcessInformation InventoryProcessInformation
//        {
//            get
//            {
//                return this.inventoryProcessInformationField;
//            }
//            set
//            {
//                this.inventoryProcessInformationField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileInventoryProcessConfiguration InventoryProcessConfiguration
//        {
//            get
//            {
//                return this.inventoryProcessConfigurationField;
//            }
//            set
//            {
//                this.inventoryProcessConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public string ScannerType
//        {
//            get
//            {
//                return this.scannerTypeField;
//            }
//            set
//            {
//                this.scannerTypeField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileLocationInventoryListScreenConfiguration LocationInventoryListScreenConfiguration
//        {
//            get
//            {
//                return this.locationInventoryListScreenConfigurationField;
//            }
//            set
//            {
//                this.locationInventoryListScreenConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileInventoryListDefaultUIConfiguration InventoryListDefaultUIConfiguration
//        {
//            get
//            {
//                return this.inventoryListDefaultUIConfigurationField;
//            }
//            set
//            {
//                this.inventoryListDefaultUIConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileDatabaseSettings DatabaseSettings
//        {
//            get
//            {
//                return this.databaseSettingsField;
//            }
//            set
//            {
//                this.databaseSettingsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileForms Forms
//        {
//            get
//            {
//                return this.formsField;
//            }
//            set
//            {
//                this.formsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileSearch Search
//        {
//            get
//            {
//                return this.searchField;
//            }
//            set
//            {
//                this.searchField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfiguration ScreensConfiguration
//        {
//            get
//            {
//                return this.screensConfigurationField;
//            }
//            set
//            {
//                this.screensConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileInventoryImage InventoryImage
//        {
//            get
//            {
//                return this.inventoryImageField;
//            }
//            set
//            {
//                this.inventoryImageField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfilePrinterSettings PrinterSettings
//        {
//            get
//            {
//                return this.printerSettingsField;
//            }
//            set
//            {
//                this.printerSettingsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileRFID RFID
//        {
//            get
//            {
//                return this.rFIDField;
//            }
//            set
//            {
//                this.rFIDField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfiguration FastStockInventoryItemsConfiguration
//        {
//            get
//            {
//                return this.fastStockInventoryItemsConfigurationField;
//            }
//            set
//            {
//                this.fastStockInventoryItemsConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public object BarcodeManipulations
//        {
//            get
//            {
//                return this.barcodeManipulationsField;
//            }
//            set
//            {
//                this.barcodeManipulationsField = value;
//            }
//        }

//        /// <remarks/>
//        public byte Version
//        {
//            get
//            {
//                return this.versionField;
//            }
//            set
//            {
//                this.versionField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileCustomer Customer
//        {
//            get
//            {
//                return this.customerField;
//            }
//            set
//            {
//                this.customerField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryProcessInformation
//    {

//        private ProfileInventoryProcessInformationCustomer customerField;

//        private ProfileInventoryProcessInformationBranch branchField;

//        private ProfileInventoryProcessInformationInventory inventoryField;

//        /// <remarks/>
//        public ProfileInventoryProcessInformationCustomer Customer
//        {
//            get
//            {
//                return this.customerField;
//            }
//            set
//            {
//                this.customerField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileInventoryProcessInformationBranch Branch
//        {
//            get
//            {
//                return this.branchField;
//            }
//            set
//            {
//                this.branchField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileInventoryProcessInformationInventory Inventory
//        {
//            get
//            {
//                return this.inventoryField;
//            }
//            set
//            {
//                this.inventoryField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryProcessInformationCustomer
//    {

//        private string nameField;

//        private ushort codeField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string name
//        {
//            get
//            {
//                return this.nameField;
//            }
//            set
//            {
//                this.nameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public ushort code
//        {
//            get
//            {
//                return this.codeField;
//            }
//            set
//            {
//                this.codeField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryProcessInformationBranch
//    {

//        private string nameField;

//        private string codeField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string name
//        {
//            get
//            {
//                return this.nameField;
//            }
//            set
//            {
//                this.nameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string code
//        {
//            get
//            {
//                return this.codeField;
//            }
//            set
//            {
//                this.codeField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryProcessInformationInventory
//    {

//        private string codeField;

//        private string created_dateField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string code
//        {
//            get
//            {
//                return this.codeField;
//            }
//            set
//            {
//                this.codeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string created_date
//        {
//            get
//            {
//                return this.created_dateField;
//            }
//            set
//            {
//                this.created_dateField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryProcessConfiguration
//    {

//        private ProfileInventoryProcessConfigurationInventoryProcessMode inventoryProcessModeField;

//        /// <remarks/>
//        public ProfileInventoryProcessConfigurationInventoryProcessMode InventoryProcessMode
//        {
//            get
//            {
//                return this.inventoryProcessModeField;
//            }
//            set
//            {
//                this.inventoryProcessModeField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryProcessConfigurationInventoryProcessMode
//    {

//        private bool assertModeEnabledField;

//        private bool stockModeEnabledField;

//        /// <remarks/>
//        public bool AssertModeEnabled
//        {
//            get
//            {
//                return this.assertModeEnabledField;
//            }
//            set
//            {
//                this.assertModeEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool StockModeEnabled
//        {
//            get
//            {
//                return this.stockModeEnabledField;
//            }
//            set
//            {
//                this.stockModeEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileLocationInventoryListScreenConfiguration
//    {

//        private bool addNewInventoryEnabledField;

//        private bool templateInventoriesEnabledField;

//        private bool signatureToVerifyClosureOfLocationRequiredField;

//        private bool addNewInventoryOfflineEnabledField;

//        /// <remarks/>
//        public bool AddNewInventoryEnabled
//        {
//            get
//            {
//                return this.addNewInventoryEnabledField;
//            }
//            set
//            {
//                this.addNewInventoryEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool TemplateInventoriesEnabled
//        {
//            get
//            {
//                return this.templateInventoriesEnabledField;
//            }
//            set
//            {
//                this.templateInventoriesEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool SignatureToVerifyClosureOfLocationRequired
//        {
//            get
//            {
//                return this.signatureToVerifyClosureOfLocationRequiredField;
//            }
//            set
//            {
//                this.signatureToVerifyClosureOfLocationRequiredField = value;
//            }
//        }

//        /// <remarks/>
//        public bool AddNewInventoryOfflineEnabled
//        {
//            get
//            {
//                return this.addNewInventoryOfflineEnabledField;
//            }
//            set
//            {
//                this.addNewInventoryOfflineEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryListDefaultUIConfiguration
//    {

//        private bool showInventoryImageIndicatorField;

//        private ProfileInventoryListDefaultUIConfigurationInventoryItemDisplayProperty[] inventoryItemsPropertiesField;

//        /// <remarks/>
//        public bool ShowInventoryImageIndicator
//        {
//            get
//            {
//                return this.showInventoryImageIndicatorField;
//            }
//            set
//            {
//                this.showInventoryImageIndicatorField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("InventoryItemDisplayProperty", IsNullable = false)]
//        public ProfileInventoryListDefaultUIConfigurationInventoryItemDisplayProperty[] InventoryItemsProperties
//        {
//            get
//            {
//                return this.inventoryItemsPropertiesField;
//            }
//            set
//            {
//                this.inventoryItemsPropertiesField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryListDefaultUIConfigurationInventoryItemDisplayProperty
//    {

//        private ProfileInventoryListDefaultUIConfigurationInventoryItemDisplayPropertyTitle titleField;

//        private bool invalidField;

//        private byte idField;

//        private string id1Field;

//        private string itemtypeField;

//        /// <remarks/>
//        public ProfileInventoryListDefaultUIConfigurationInventoryItemDisplayPropertyTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string itemtype
//        {
//            get
//            {
//                return this.itemtypeField;
//            }
//            set
//            {
//                this.itemtypeField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryListDefaultUIConfigurationInventoryItemDisplayPropertyTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileDatabaseSettings
//    {

//        private string uIDKeyField;

//        private string currentInventoryDeviceIdPropertyField;

//        private string currentInventoryUserNamePropertyField;

//        private bool clearInventoryDataAfterUploadField;

//        private object currentInventoryDeviceNamePropertyField;

//        /// <remarks/>
//        public string UIDKey
//        {
//            get
//            {
//                return this.uIDKeyField;
//            }
//            set
//            {
//                this.uIDKeyField = value;
//            }
//        }

//        /// <remarks/>
//        public string CurrentInventoryDeviceIdProperty
//        {
//            get
//            {
//                return this.currentInventoryDeviceIdPropertyField;
//            }
//            set
//            {
//                this.currentInventoryDeviceIdPropertyField = value;
//            }
//        }

//        /// <remarks/>
//        public string CurrentInventoryUserNameProperty
//        {
//            get
//            {
//                return this.currentInventoryUserNamePropertyField;
//            }
//            set
//            {
//                this.currentInventoryUserNamePropertyField = value;
//            }
//        }

//        /// <remarks/>
//        public bool ClearInventoryDataAfterUpload
//        {
//            get
//            {
//                return this.clearInventoryDataAfterUploadField;
//            }
//            set
//            {
//                this.clearInventoryDataAfterUploadField = value;
//            }
//        }

//        /// <remarks/>
//        public object CurrentInventoryDeviceNameProperty
//        {
//            get
//            {
//                return this.currentInventoryDeviceNamePropertyField;
//            }
//            set
//            {
//                this.currentInventoryDeviceNamePropertyField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileForms
//    {

//        private ProfileFormsForm formField;

//        /// <remarks/>
//        public ProfileFormsForm Form
//        {
//            get
//            {
//                return this.formField;
//            }
//            set
//            {
//                this.formField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsForm
//    {

//        private ProfileFormsFormField[] fieldField;

//        private bool keepAllFieldsOnItemCodeChangeField;

//        private string idField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("Field")]
//        public ProfileFormsFormField[] Field
//        {
//            get
//            {
//                return this.fieldField;
//            }
//            set
//            {
//                this.fieldField = value;
//            }
//        }

//        /// <remarks/>
//        public bool KeepAllFieldsOnItemCodeChange
//        {
//            get
//            {
//                return this.keepAllFieldsOnItemCodeChangeField;
//            }
//            set
//            {
//                this.keepAllFieldsOnItemCodeChangeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormField
//    {

//        private ProfileFormsFormFieldActions actionsField;

//        private ProfileFormsFormFieldDataSource dataSourceField;

//        private ProfileFormsFormFieldDataTarget dataTargetField;

//        private ProfileFormsFormFieldDetails detailsField;

//        private ProfileFormsFormFieldTitles titlesField;

//        private bool invalidField;

//        private byte idField;

//        /// <remarks/>
//        public ProfileFormsFormFieldActions Actions
//        {
//            get
//            {
//                return this.actionsField;
//            }
//            set
//            {
//                this.actionsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFormsFormFieldDataSource DataSource
//        {
//            get
//            {
//                return this.dataSourceField;
//            }
//            set
//            {
//                this.dataSourceField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFormsFormFieldDataTarget DataTarget
//        {
//            get
//            {
//                return this.dataTargetField;
//            }
//            set
//            {
//                this.dataTargetField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFormsFormFieldDetails Details
//        {
//            get
//            {
//                return this.detailsField;
//            }
//            set
//            {
//                this.detailsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFormsFormFieldTitles Titles
//        {
//            get
//            {
//                return this.titlesField;
//            }
//            set
//            {
//                this.titlesField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldActions
//    {

//        private object[] itemsField;

//        private ItemsChoiceType[] itemsElementNameField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("AutoGenerateCode", typeof(bool))]
//        [System.Xml.Serialization.XmlElementAttribute("EnabledFilters", typeof(ProfileFormsFormFieldActionsEnabledFilters))]
//        [System.Xml.Serialization.XmlElementAttribute("SelectInFocus", typeof(bool))]
//        [System.Xml.Serialization.XmlChoiceIdentifierAttribute("ItemsElementName")]
//        public object[] Items
//        {
//            get
//            {
//                return this.itemsField;
//            }
//            set
//            {
//                this.itemsField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("ItemsElementName")]
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public ItemsChoiceType[] ItemsElementName
//        {
//            get
//            {
//                return this.itemsElementNameField;
//            }
//            set
//            {
//                this.itemsElementNameField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldActionsEnabledFilters
//    {

//        private ProfileFormsFormFieldActionsEnabledFiltersEnabledFiler[] enabledFilerField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("EnabledFiler")]
//        public ProfileFormsFormFieldActionsEnabledFiltersEnabledFiler[] EnabledFiler
//        {
//            get
//            {
//                return this.enabledFilerField;
//            }
//            set
//            {
//                this.enabledFilerField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldActionsEnabledFiltersEnabledFiler
//    {

//        private ProfileFormsFormFieldActionsEnabledFiltersEnabledFilerEnabled enabledField;

//        private ProfileFormsFormFieldActionsEnabledFiltersEnabledFilerFilter filterField;

//        /// <remarks/>
//        public ProfileFormsFormFieldActionsEnabledFiltersEnabledFilerEnabled Enabled
//        {
//            get
//            {
//                return this.enabledField;
//            }
//            set
//            {
//                this.enabledField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFormsFormFieldActionsEnabledFiltersEnabledFilerFilter Filter
//        {
//            get
//            {
//                return this.filterField;
//            }
//            set
//            {
//                this.filterField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldActionsEnabledFiltersEnabledFilerEnabled
//    {

//        private string fieldconditionField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldcondition
//        {
//            get
//            {
//                return this.fieldconditionField;
//            }
//            set
//            {
//                this.fieldconditionField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldActionsEnabledFiltersEnabledFilerFilter
//    {

//        private string typeField;

//        private string valueField;

//        private string valueToRegField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string type
//        {
//            get
//            {
//                return this.typeField;
//            }
//            set
//            {
//                this.typeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string value
//        {
//            get
//            {
//                return this.valueField;
//            }
//            set
//            {
//                this.valueField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string valueToReg
//        {
//            get
//            {
//                return this.valueToRegField;
//            }
//            set
//            {
//                this.valueToRegField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(IncludeInSchema = false)]
//    public enum ItemsChoiceType
//    {

//        /// <remarks/>
//        AutoGenerateCode,

//        /// <remarks/>
//        EnabledFilters,

//        /// <remarks/>
//        SelectInFocus,
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldDataSource
//    {

//        private string fieldnameField;

//        private string keyboard_typeField;

//        private string tablenameField;

//        private string fieldnametoshowField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldname
//        {
//            get
//            {
//                return this.fieldnameField;
//            }
//            set
//            {
//                this.fieldnameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string keyboard_type
//        {
//            get
//            {
//                return this.keyboard_typeField;
//            }
//            set
//            {
//                this.keyboard_typeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string tablename
//        {
//            get
//            {
//                return this.tablenameField;
//            }
//            set
//            {
//                this.tablenameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldnametoshow
//        {
//            get
//            {
//                return this.fieldnametoshowField;
//            }
//            set
//            {
//                this.fieldnametoshowField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldDataTarget
//    {

//        private string fieldnameField;

//        private string tablenameField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldname
//        {
//            get
//            {
//                return this.fieldnameField;
//            }
//            set
//            {
//                this.fieldnameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string tablename
//        {
//            get
//            {
//                return this.tablenameField;
//            }
//            set
//            {
//                this.tablenameField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldDetails
//    {

//        private string defaultField;

//        private string idField;

//        private string itemtypeField;

//        private string mandatoryField;

//        private string typeField;

//        private string typeviewField;

//        private string viewonlyField;

//        private string camera_barcode_scanner_enableField;

//        private string negative_value_enableField;

//        private bool add_enableField;

//        private bool add_enableFieldSpecified;

//        private bool clear_enableField;

//        private bool clear_enableFieldSpecified;

//        private bool zero_value_enableField;

//        private bool zero_value_enableFieldSpecified;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string @default
//        {
//            get
//            {
//                return this.defaultField;
//            }
//            set
//            {
//                this.defaultField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string itemtype
//        {
//            get
//            {
//                return this.itemtypeField;
//            }
//            set
//            {
//                this.itemtypeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string mandatory
//        {
//            get
//            {
//                return this.mandatoryField;
//            }
//            set
//            {
//                this.mandatoryField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string type
//        {
//            get
//            {
//                return this.typeField;
//            }
//            set
//            {
//                this.typeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string typeview
//        {
//            get
//            {
//                return this.typeviewField;
//            }
//            set
//            {
//                this.typeviewField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string viewonly
//        {
//            get
//            {
//                return this.viewonlyField;
//            }
//            set
//            {
//                this.viewonlyField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string camera_barcode_scanner_enable
//        {
//            get
//            {
//                return this.camera_barcode_scanner_enableField;
//            }
//            set
//            {
//                this.camera_barcode_scanner_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string negative_value_enable
//        {
//            get
//            {
//                return this.negative_value_enableField;
//            }
//            set
//            {
//                this.negative_value_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public bool add_enable
//        {
//            get
//            {
//                return this.add_enableField;
//            }
//            set
//            {
//                this.add_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool add_enableSpecified
//        {
//            get
//            {
//                return this.add_enableFieldSpecified;
//            }
//            set
//            {
//                this.add_enableFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public bool clear_enable
//        {
//            get
//            {
//                return this.clear_enableField;
//            }
//            set
//            {
//                this.clear_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool clear_enableSpecified
//        {
//            get
//            {
//                return this.clear_enableFieldSpecified;
//            }
//            set
//            {
//                this.clear_enableFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public bool zero_value_enable
//        {
//            get
//            {
//                return this.zero_value_enableField;
//            }
//            set
//            {
//                this.zero_value_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool zero_value_enableSpecified
//        {
//            get
//            {
//                return this.zero_value_enableFieldSpecified;
//            }
//            set
//            {
//                this.zero_value_enableFieldSpecified = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldTitles
//    {

//        private ProfileFormsFormFieldTitlesTitle titleField;

//        private ProfileFormsFormFieldTitlesDescription descriptionField;

//        /// <remarks/>
//        public ProfileFormsFormFieldTitlesTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFormsFormFieldTitlesDescription Description
//        {
//            get
//            {
//                return this.descriptionField;
//            }
//            set
//            {
//                this.descriptionField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldTitlesTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFormsFormFieldTitlesDescription
//    {

//        private string enField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearch
//    {

//        private ProfileSearchSearchByScannerScreenConfiguration searchByScannerScreenConfigurationField;

//        private ProfileSearchSearchInCatalogScreenConfiguration searchInCatalogScreenConfigurationField;

//        private ProfileSearchSearchInLocationScreenConfiguration searchInLocationScreenConfigurationField;

//        private object ignoreCharField;

//        /// <remarks/>
//        public ProfileSearchSearchByScannerScreenConfiguration SearchByScannerScreenConfiguration
//        {
//            get
//            {
//                return this.searchByScannerScreenConfigurationField;
//            }
//            set
//            {
//                this.searchByScannerScreenConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileSearchSearchInCatalogScreenConfiguration SearchInCatalogScreenConfiguration
//        {
//            get
//            {
//                return this.searchInCatalogScreenConfigurationField;
//            }
//            set
//            {
//                this.searchInCatalogScreenConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileSearchSearchInLocationScreenConfiguration SearchInLocationScreenConfiguration
//        {
//            get
//            {
//                return this.searchInLocationScreenConfigurationField;
//            }
//            set
//            {
//                this.searchInLocationScreenConfigurationField = value;
//            }
//        }

//        /// <remarks/>
//        public object IgnoreChar
//        {
//            get
//            {
//                return this.ignoreCharField;
//            }
//            set
//            {
//                this.ignoreCharField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchByScannerScreenConfiguration
//    {

//        private bool addNewInventoryEnabledField;

//        private bool cameraBarcodeScannerEnabledField;

//        private bool navigateBackEnabledField;

//        private ProfileSearchSearchByScannerScreenConfigurationSearchByProperty[] searchByPropertiesField;

//        private ProfileSearchSearchByScannerScreenConfigurationSearchDisplayProperty[] searchByScannerResultListDisplayPropertiesField;

//        /// <remarks/>
//        public bool AddNewInventoryEnabled
//        {
//            get
//            {
//                return this.addNewInventoryEnabledField;
//            }
//            set
//            {
//                this.addNewInventoryEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool CameraBarcodeScannerEnabled
//        {
//            get
//            {
//                return this.cameraBarcodeScannerEnabledField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool NavigateBackEnabled
//        {
//            get
//            {
//                return this.navigateBackEnabledField;
//            }
//            set
//            {
//                this.navigateBackEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchByProperty", IsNullable = false)]
//        public ProfileSearchSearchByScannerScreenConfigurationSearchByProperty[] SearchByProperties
//        {
//            get
//            {
//                return this.searchByPropertiesField;
//            }
//            set
//            {
//                this.searchByPropertiesField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchDisplayProperty", IsNullable = false)]
//        public ProfileSearchSearchByScannerScreenConfigurationSearchDisplayProperty[] SearchByScannerResultListDisplayProperties
//        {
//            get
//            {
//                return this.searchByScannerResultListDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchByScannerResultListDisplayPropertiesField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchByScannerScreenConfigurationSearchByProperty
//    {

//        private ProfileSearchSearchByScannerScreenConfigurationSearchByPropertyTitle titleField;

//        private byte idField;

//        private string id1Field;

//        /// <remarks/>
//        public ProfileSearchSearchByScannerScreenConfigurationSearchByPropertyTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchByScannerScreenConfigurationSearchByPropertyTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchByScannerScreenConfigurationSearchDisplayProperty
//    {

//        private object[] itemsField;

//        private string idField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlElementAttribute("Title", typeof(ProfileSearchSearchByScannerScreenConfigurationSearchDisplayPropertyTitle))]
//        [System.Xml.Serialization.XmlElementAttribute("id", typeof(byte))]
//        [System.Xml.Serialization.XmlElementAttribute("invalid", typeof(bool))]
//        public object[] Items
//        {
//            get
//            {
//                return this.itemsField;
//            }
//            set
//            {
//                this.itemsField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchByScannerScreenConfigurationSearchDisplayPropertyTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInCatalogScreenConfiguration
//    {

//        private bool addNewItemIntoCatalogEnabledField;

//        private bool cameraBarcodeScannerEnabledField;

//        private ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayProperties searchInCatalogResultListsDisplayPropertiesField;

//        /// <remarks/>
//        public bool AddNewItemIntoCatalogEnabled
//        {
//            get
//            {
//                return this.addNewItemIntoCatalogEnabledField;
//            }
//            set
//            {
//                this.addNewItemIntoCatalogEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool CameraBarcodeScannerEnabled
//        {
//            get
//            {
//                return this.cameraBarcodeScannerEnabledField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayProperties SearchInCatalogResultListsDisplayProperties
//        {
//            get
//            {
//                return this.searchInCatalogResultListsDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInCatalogResultListsDisplayPropertiesField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayProperties
//    {

//        private ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayProperty[] searchInCatalogByItemCodeResultListDisplayPropertiesField;

//        private ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayProperty1[] searchInCatalogByItemNameResultListDisplayPropertiesField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchDisplayProperty", IsNullable = false)]
//        public ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayProperty[] SearchInCatalogByItemCodeResultListDisplayProperties
//        {
//            get
//            {
//                return this.searchInCatalogByItemCodeResultListDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInCatalogByItemCodeResultListDisplayPropertiesField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchDisplayProperty", IsNullable = false)]
//        public ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayProperty1[] SearchInCatalogByItemNameResultListDisplayProperties
//        {
//            get
//            {
//                return this.searchInCatalogByItemNameResultListDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInCatalogByItemNameResultListDisplayPropertiesField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayProperty
//    {

//        private ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayPropertyTitle titleField;

//        private bool invalidField;

//        private byte idField;

//        private string id1Field;

//        /// <remarks/>
//        public ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayPropertyTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayPropertyTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayProperty1
//    {

//        private ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayPropertyTitle1 titleField;

//        private bool invalidField;

//        private byte idField;

//        private string id1Field;

//        /// <remarks/>
//        public ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayPropertyTitle1 Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInCatalogScreenConfigurationSearchInCatalogResultListsDisplayPropertiesSearchDisplayPropertyTitle1
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfiguration
//    {

//        private bool cameraBarcodeScannerEnabledField;

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayProperties searchInLocationResultListsDisplayPropertiesField;

//        private bool addNewItemIntoCatalogEnabledField;

//        /// <remarks/>
//        public bool CameraBarcodeScannerEnabled
//        {
//            get
//            {
//                return this.cameraBarcodeScannerEnabledField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayProperties SearchInLocationResultListsDisplayProperties
//        {
//            get
//            {
//                return this.searchInLocationResultListsDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInLocationResultListsDisplayPropertiesField = value;
//            }
//        }

//        /// <remarks/>
//        public bool AddNewItemIntoCatalogEnabled
//        {
//            get
//            {
//                return this.addNewItemIntoCatalogEnabledField;
//            }
//            set
//            {
//                this.addNewItemIntoCatalogEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayProperties
//    {

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty[] searchInLocationByItemSerialResultListDisplayPropertiesField;

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty1[] searchInLocationByItemCodeResultListDisplayPropertiesField;

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty2[] searchInLocationByItemNameResultListDisplayPropertiesField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchDisplayProperty", IsNullable = false)]
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty[] SearchInLocationByItemSerialResultListDisplayProperties
//        {
//            get
//            {
//                return this.searchInLocationByItemSerialResultListDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInLocationByItemSerialResultListDisplayPropertiesField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchDisplayProperty", IsNullable = false)]
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty1[] SearchInLocationByItemCodeResultListDisplayProperties
//        {
//            get
//            {
//                return this.searchInLocationByItemCodeResultListDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInLocationByItemCodeResultListDisplayPropertiesField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("SearchDisplayProperty", IsNullable = false)]
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty2[] SearchInLocationByItemNameResultListDisplayProperties
//        {
//            get
//            {
//                return this.searchInLocationByItemNameResultListDisplayPropertiesField;
//            }
//            set
//            {
//                this.searchInLocationByItemNameResultListDisplayPropertiesField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty
//    {

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle titleField;

//        private bool invalidField;

//        private byte idField;

//        private string id1Field;

//        private string heField;

//        /// <remarks/>
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty1
//    {

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle1 titleField;

//        private bool invalidField;

//        private byte idField;

//        private string id1Field;

//        private string heField;

//        /// <remarks/>
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle1 Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle1
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayProperty2
//    {

//        private ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle2 titleField;

//        private bool invalidField;

//        private byte idField;

//        private string id1Field;

//        private string heField;

//        /// <remarks/>
//        public ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle2 Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute("id")]
//        public string id1
//        {
//            get
//            {
//                return this.id1Field;
//            }
//            set
//            {
//                this.id1Field = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileSearchSearchInLocationScreenConfigurationSearchInLocationResultListsDisplayPropertiesSearchDisplayPropertyTitle2
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfiguration
//    {

//        private ProfileScreensConfigurationAddNewLocationScreen addNewLocationScreenField;

//        private ProfileScreensConfigurationItemCodeSummaryScreen itemCodeSummaryScreenField;

//        private ProfileScreensConfigurationMoveInventoriesScreen moveInventoriesScreenField;

//        private ProfileScreensConfigurationAddQInventoryItemsInFastWayScreen addQInventoryItemsInFastWayScreenField;

//        private ProfileScreensConfigurationAddSNInventoryItemsInFastWayScreen addSNInventoryItemsInFastWayScreenField;

//        private ProfileScreensConfigurationWarehouseScreenRFID warehouseScreenRFIDField;

//        private ProfileScreensConfigurationAssertInventoryScreen assertInventoryScreenField;

//        /// <remarks/>
//        public ProfileScreensConfigurationAddNewLocationScreen AddNewLocationScreen
//        {
//            get
//            {
//                return this.addNewLocationScreenField;
//            }
//            set
//            {
//                this.addNewLocationScreenField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationItemCodeSummaryScreen ItemCodeSummaryScreen
//        {
//            get
//            {
//                return this.itemCodeSummaryScreenField;
//            }
//            set
//            {
//                this.itemCodeSummaryScreenField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationMoveInventoriesScreen MoveInventoriesScreen
//        {
//            get
//            {
//                return this.moveInventoriesScreenField;
//            }
//            set
//            {
//                this.moveInventoriesScreenField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationAddQInventoryItemsInFastWayScreen AddQInventoryItemsInFastWayScreen
//        {
//            get
//            {
//                return this.addQInventoryItemsInFastWayScreenField;
//            }
//            set
//            {
//                this.addQInventoryItemsInFastWayScreenField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationAddSNInventoryItemsInFastWayScreen AddSNInventoryItemsInFastWayScreen
//        {
//            get
//            {
//                return this.addSNInventoryItemsInFastWayScreenField;
//            }
//            set
//            {
//                this.addSNInventoryItemsInFastWayScreenField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationWarehouseScreenRFID WarehouseScreenRFID
//        {
//            get
//            {
//                return this.warehouseScreenRFIDField;
//            }
//            set
//            {
//                this.warehouseScreenRFIDField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationAssertInventoryScreen AssertInventoryScreen
//        {
//            get
//            {
//                return this.assertInventoryScreenField;
//            }
//            set
//            {
//                this.assertInventoryScreenField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationAddNewLocationScreen
//    {

//        private bool screenEnabledField;

//        private bool screenEnabledOfflineField;

//        /// <remarks/>
//        public bool ScreenEnabled
//        {
//            get
//            {
//                return this.screenEnabledField;
//            }
//            set
//            {
//                this.screenEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool ScreenEnabledOffline
//        {
//            get
//            {
//                return this.screenEnabledOfflineField;
//            }
//            set
//            {
//                this.screenEnabledOfflineField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationItemCodeSummaryScreen
//    {

//        private bool screenEnabledField;

//        /// <remarks/>
//        public bool ScreenEnabled
//        {
//            get
//            {
//                return this.screenEnabledField;
//            }
//            set
//            {
//                this.screenEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationMoveInventoriesScreen
//    {

//        private ProfileScreensConfigurationMoveInventoriesScreenInventoryMoveSearchProperty inventoryMoveSearchPropertyField;

//        private bool screenEnabledField;

//        /// <remarks/>
//        public ProfileScreensConfigurationMoveInventoriesScreenInventoryMoveSearchProperty InventoryMoveSearchProperty
//        {
//            get
//            {
//                return this.inventoryMoveSearchPropertyField;
//            }
//            set
//            {
//                this.inventoryMoveSearchPropertyField = value;
//            }
//        }

//        /// <remarks/>
//        public bool ScreenEnabled
//        {
//            get
//            {
//                return this.screenEnabledField;
//            }
//            set
//            {
//                this.screenEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationMoveInventoriesScreenInventoryMoveSearchProperty
//    {

//        private ProfileScreensConfigurationMoveInventoriesScreenInventoryMoveSearchPropertyTitle titleField;

//        private string idField;

//        /// <remarks/>
//        public ProfileScreensConfigurationMoveInventoriesScreenInventoryMoveSearchPropertyTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationMoveInventoriesScreenInventoryMoveSearchPropertyTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationAddQInventoryItemsInFastWayScreen
//    {

//        private bool cameraBarcodeScannerEnabledField;

//        private bool screenEnabledField;

//        /// <remarks/>
//        public bool CameraBarcodeScannerEnabled
//        {
//            get
//            {
//                return this.cameraBarcodeScannerEnabledField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool ScreenEnabled
//        {
//            get
//            {
//                return this.screenEnabledField;
//            }
//            set
//            {
//                this.screenEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationAddSNInventoryItemsInFastWayScreen
//    {

//        private bool cameraBarcodeScannerEnabledField;

//        private ProfileScreensConfigurationAddSNInventoryItemsInFastWayScreenDefaultValues defaultValuesField;

//        private bool screenEnabledField;

//        /// <remarks/>
//        public bool CameraBarcodeScannerEnabled
//        {
//            get
//            {
//                return this.cameraBarcodeScannerEnabledField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileScreensConfigurationAddSNInventoryItemsInFastWayScreenDefaultValues DefaultValues
//        {
//            get
//            {
//                return this.defaultValuesField;
//            }
//            set
//            {
//                this.defaultValuesField = value;
//            }
//        }

//        /// <remarks/>
//        public bool ScreenEnabled
//        {
//            get
//            {
//                return this.screenEnabledField;
//            }
//            set
//            {
//                this.screenEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationAddSNInventoryItemsInFastWayScreenDefaultValues
//    {

//        private string defaultItemCodeField;

//        private byte defaultQuantityField;

//        /// <remarks/>
//        public string DefaultItemCode
//        {
//            get
//            {
//                return this.defaultItemCodeField;
//            }
//            set
//            {
//                this.defaultItemCodeField = value;
//            }
//        }

//        /// <remarks/>
//        public byte DefaultQuantity
//        {
//            get
//            {
//                return this.defaultQuantityField;
//            }
//            set
//            {
//                this.defaultQuantityField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationWarehouseScreenRFID
//    {

//        private bool screenEnabledField;

//        private bool warehouseScreenRFIDConnectionBeforeOpenRequiredField;

//        /// <remarks/>
//        public bool ScreenEnabled
//        {
//            get
//            {
//                return this.screenEnabledField;
//            }
//            set
//            {
//                this.screenEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public bool WarehouseScreenRFIDConnectionBeforeOpenRequired
//        {
//            get
//            {
//                return this.warehouseScreenRFIDConnectionBeforeOpenRequiredField;
//            }
//            set
//            {
//                this.warehouseScreenRFIDConnectionBeforeOpenRequiredField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileScreensConfigurationAssertInventoryScreen
//    {

//        private bool inventoryWizardField;

//        private bool cameraBarcodeScannerEnabledField;

//        /// <remarks/>
//        public bool InventoryWizard
//        {
//            get
//            {
//                return this.inventoryWizardField;
//            }
//            set
//            {
//                this.inventoryWizardField = value;
//            }
//        }

//        /// <remarks/>
//        public bool CameraBarcodeScannerEnabled
//        {
//            get
//            {
//                return this.cameraBarcodeScannerEnabledField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerEnabledField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileInventoryImage
//    {

//        private bool inventoryImageEnabledField;

//        private byte imageQualityField;

//        private object inventoryImagePropertyIdField;

//        /// <remarks/>
//        public bool InventoryImageEnabled
//        {
//            get
//            {
//                return this.inventoryImageEnabledField;
//            }
//            set
//            {
//                this.inventoryImageEnabledField = value;
//            }
//        }

//        /// <remarks/>
//        public byte ImageQuality
//        {
//            get
//            {
//                return this.imageQualityField;
//            }
//            set
//            {
//                this.imageQualityField = value;
//            }
//        }

//        /// <remarks/>
//        public object InventoryImagePropertyId
//        {
//            get
//            {
//                return this.inventoryImagePropertyIdField;
//            }
//            set
//            {
//                this.inventoryImagePropertyIdField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfilePrinterSettings
//    {

//        private ProfilePrinterSettingsZebraPrinter zebraPrinterField;

//        /// <remarks/>
//        public ProfilePrinterSettingsZebraPrinter ZebraPrinter
//        {
//            get
//            {
//                return this.zebraPrinterField;
//            }
//            set
//            {
//                this.zebraPrinterField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfilePrinterSettingsZebraPrinter
//    {

//        private ProfilePrinterSettingsZebraPrinterPrintingFormats printingFormatsField;

//        /// <remarks/>
//        public ProfilePrinterSettingsZebraPrinterPrintingFormats PrintingFormats
//        {
//            get
//            {
//                return this.printingFormatsField;
//            }
//            set
//            {
//                this.printingFormatsField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfilePrinterSettingsZebraPrinterPrintingFormats
//    {

//        private ProfilePrinterSettingsZebraPrinterPrintingFormatsPrintingFormat printingFormatField;

//        /// <remarks/>
//        public ProfilePrinterSettingsZebraPrinterPrintingFormatsPrintingFormat PrintingFormat
//        {
//            get
//            {
//                return this.printingFormatField;
//            }
//            set
//            {
//                this.printingFormatField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfilePrinterSettingsZebraPrinterPrintingFormatsPrintingFormat
//    {

//        private string formatField;

//        private ProfilePrinterSettingsZebraPrinterPrintingFormatsPrintingFormatFieldMapping[] fieldsMappingField;

//        /// <remarks/>
//        public string Format
//        {
//            get
//            {
//                return this.formatField;
//            }
//            set
//            {
//                this.formatField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("FieldMapping", IsNullable = false)]
//        public ProfilePrinterSettingsZebraPrinterPrintingFormatsPrintingFormatFieldMapping[] FieldsMapping
//        {
//            get
//            {
//                return this.fieldsMappingField;
//            }
//            set
//            {
//                this.fieldsMappingField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfilePrinterSettingsZebraPrinterPrintingFormatsPrintingFormatFieldMapping
//    {

//        private string nameField;

//        private string dateFormatField;

//        private string inventoryPropertyIdField;

//        private bool reverseValueField;

//        private bool reverseValueFieldSpecified;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string name
//        {
//            get
//            {
//                return this.nameField;
//            }
//            set
//            {
//                this.nameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string dateFormat
//        {
//            get
//            {
//                return this.dateFormatField;
//            }
//            set
//            {
//                this.dateFormatField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string inventoryPropertyId
//        {
//            get
//            {
//                return this.inventoryPropertyIdField;
//            }
//            set
//            {
//                this.inventoryPropertyIdField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public bool reverseValue
//        {
//            get
//            {
//                return this.reverseValueField;
//            }
//            set
//            {
//                this.reverseValueField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool reverseValueSpecified
//        {
//            get
//            {
//                return this.reverseValueFieldSpecified;
//            }
//            set
//            {
//                this.reverseValueFieldSpecified = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileRFID
//    {

//        private byte qCodeTypeField;

//        private ProfileRFIDRFIDCommand[] rFIDCommandsField;

//        private string rFIDTagWrittenField;

//        private byte sNCodeTypeField;

//        /// <remarks/>
//        public byte QCodeType
//        {
//            get
//            {
//                return this.qCodeTypeField;
//            }
//            set
//            {
//                this.qCodeTypeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("RFIDCommand", IsNullable = false)]
//        public ProfileRFIDRFIDCommand[] RFIDCommands
//        {
//            get
//            {
//                return this.rFIDCommandsField;
//            }
//            set
//            {
//                this.rFIDCommandsField = value;
//            }
//        }

//        /// <remarks/>
//        public string RFIDTagWritten
//        {
//            get
//            {
//                return this.rFIDTagWrittenField;
//            }
//            set
//            {
//                this.rFIDTagWrittenField = value;
//            }
//        }

//        /// <remarks/>
//        public byte SNCodeType
//        {
//            get
//            {
//                return this.sNCodeTypeField;
//            }
//            set
//            {
//                this.sNCodeTypeField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileRFIDRFIDCommand
//    {

//        private string commandField;

//        private string typeField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string command
//        {
//            get
//            {
//                return this.commandField;
//            }
//            set
//            {
//                this.commandField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string type
//        {
//            get
//            {
//                return this.typeField;
//            }
//            set
//            {
//                this.typeField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfiguration
//    {

//        private byte defaultAutomaticQuantityField;

//        private ProfileFastStockInventoryItemsConfigurationField[] editFormSettingsField;

//        private string addDefaultQuantityModeField;

//        private bool insertNotExistInCatalogItemsField;

//        private bool insertDetailsForNotExistInCatalogItemsField;

//        private bool caseSensitiveItemCodeField;

//        private bool cameraBarcodeScannerStockLocationField;

//        private bool cameraBarcodeScannerStockInventoryField;

//        /// <remarks/>
//        public byte DefaultAutomaticQuantity
//        {
//            get
//            {
//                return this.defaultAutomaticQuantityField;
//            }
//            set
//            {
//                this.defaultAutomaticQuantityField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlArrayItemAttribute("Field", IsNullable = false)]
//        public ProfileFastStockInventoryItemsConfigurationField[] EditFormSettings
//        {
//            get
//            {
//                return this.editFormSettingsField;
//            }
//            set
//            {
//                this.editFormSettingsField = value;
//            }
//        }

//        /// <remarks/>
//        public string AddDefaultQuantityMode
//        {
//            get
//            {
//                return this.addDefaultQuantityModeField;
//            }
//            set
//            {
//                this.addDefaultQuantityModeField = value;
//            }
//        }

//        /// <remarks/>
//        public bool InsertNotExistInCatalogItems
//        {
//            get
//            {
//                return this.insertNotExistInCatalogItemsField;
//            }
//            set
//            {
//                this.insertNotExistInCatalogItemsField = value;
//            }
//        }

//        /// <remarks/>
//        public bool InsertDetailsForNotExistInCatalogItems
//        {
//            get
//            {
//                return this.insertDetailsForNotExistInCatalogItemsField;
//            }
//            set
//            {
//                this.insertDetailsForNotExistInCatalogItemsField = value;
//            }
//        }

//        /// <remarks/>
//        public bool CaseSensitiveItemCode
//        {
//            get
//            {
//                return this.caseSensitiveItemCodeField;
//            }
//            set
//            {
//                this.caseSensitiveItemCodeField = value;
//            }
//        }

//        /// <remarks/>
//        public bool CameraBarcodeScannerStockLocation
//        {
//            get
//            {
//                return this.cameraBarcodeScannerStockLocationField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerStockLocationField = value;
//            }
//        }

//        /// <remarks/>
//        public bool CameraBarcodeScannerStockInventory
//        {
//            get
//            {
//                return this.cameraBarcodeScannerStockInventoryField;
//            }
//            set
//            {
//                this.cameraBarcodeScannerStockInventoryField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationField
//    {

//        private ProfileFastStockInventoryItemsConfigurationFieldActions actionsField;

//        private ProfileFastStockInventoryItemsConfigurationFieldDataSource dataSourceField;

//        private ProfileFastStockInventoryItemsConfigurationFieldDataTarget dataTargetField;

//        private ProfileFastStockInventoryItemsConfigurationFieldDetails detailsField;

//        private ProfileFastStockInventoryItemsConfigurationFieldTitles titlesField;

//        private bool invalidField;

//        private byte idField;

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldActions Actions
//        {
//            get
//            {
//                return this.actionsField;
//            }
//            set
//            {
//                this.actionsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldDataSource DataSource
//        {
//            get
//            {
//                return this.dataSourceField;
//            }
//            set
//            {
//                this.dataSourceField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldDataTarget DataTarget
//        {
//            get
//            {
//                return this.dataTargetField;
//            }
//            set
//            {
//                this.dataTargetField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldDetails Details
//        {
//            get
//            {
//                return this.detailsField;
//            }
//            set
//            {
//                this.detailsField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldTitles Titles
//        {
//            get
//            {
//                return this.titlesField;
//            }
//            set
//            {
//                this.titlesField = value;
//            }
//        }

//        /// <remarks/>
//        public bool invalid
//        {
//            get
//            {
//                return this.invalidField;
//            }
//            set
//            {
//                this.invalidField = value;
//            }
//        }

//        /// <remarks/>
//        public byte id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldActions
//    {

//        private bool autoGenerateCodeField;

//        private bool autoGenerateCodeFieldSpecified;

//        private ProfileFastStockInventoryItemsConfigurationFieldActionsValidations validationsField;

//        private bool selectInFocusField;

//        private bool selectInFocusFieldSpecified;

//        /// <remarks/>
//        public bool AutoGenerateCode
//        {
//            get
//            {
//                return this.autoGenerateCodeField;
//            }
//            set
//            {
//                this.autoGenerateCodeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool AutoGenerateCodeSpecified
//        {
//            get
//            {
//                return this.autoGenerateCodeFieldSpecified;
//            }
//            set
//            {
//                this.autoGenerateCodeFieldSpecified = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldActionsValidations Validations
//        {
//            get
//            {
//                return this.validationsField;
//            }
//            set
//            {
//                this.validationsField = value;
//            }
//        }

//        /// <remarks/>
//        public bool SelectInFocus
//        {
//            get
//            {
//                return this.selectInFocusField;
//            }
//            set
//            {
//                this.selectInFocusField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool SelectInFocusSpecified
//        {
//            get
//            {
//                return this.selectInFocusFieldSpecified;
//            }
//            set
//            {
//                this.selectInFocusFieldSpecified = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldActionsValidations
//    {

//        private ProfileFastStockInventoryItemsConfigurationFieldActionsValidationsValidation validationField;

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldActionsValidationsValidation Validation
//        {
//            get
//            {
//                return this.validationField;
//            }
//            set
//            {
//                this.validationField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldActionsValidationsValidation
//    {

//        private string enField;

//        private string regField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string reg
//        {
//            get
//            {
//                return this.regField;
//            }
//            set
//            {
//                this.regField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldDataSource
//    {

//        private string fieldnameField;

//        private string keyboard_typeField;

//        private string tablenameField;

//        private string fieldnametoshowField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldname
//        {
//            get
//            {
//                return this.fieldnameField;
//            }
//            set
//            {
//                this.fieldnameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string keyboard_type
//        {
//            get
//            {
//                return this.keyboard_typeField;
//            }
//            set
//            {
//                this.keyboard_typeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string tablename
//        {
//            get
//            {
//                return this.tablenameField;
//            }
//            set
//            {
//                this.tablenameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldnametoshow
//        {
//            get
//            {
//                return this.fieldnametoshowField;
//            }
//            set
//            {
//                this.fieldnametoshowField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldDataTarget
//    {

//        private string fieldnameField;

//        private string tablenameField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string fieldname
//        {
//            get
//            {
//                return this.fieldnameField;
//            }
//            set
//            {
//                this.fieldnameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string tablename
//        {
//            get
//            {
//                return this.tablenameField;
//            }
//            set
//            {
//                this.tablenameField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldDetails
//    {

//        private string defaultField;

//        private string idField;

//        private string itemtypeField;

//        private string mandatoryField;

//        private string typeField;

//        private string typeviewField;

//        private string viewonlyField;

//        private string negative_value_enableField;

//        private bool add_enableField;

//        private bool add_enableFieldSpecified;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string @default
//        {
//            get
//            {
//                return this.defaultField;
//            }
//            set
//            {
//                this.defaultField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string id
//        {
//            get
//            {
//                return this.idField;
//            }
//            set
//            {
//                this.idField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string itemtype
//        {
//            get
//            {
//                return this.itemtypeField;
//            }
//            set
//            {
//                this.itemtypeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string mandatory
//        {
//            get
//            {
//                return this.mandatoryField;
//            }
//            set
//            {
//                this.mandatoryField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string type
//        {
//            get
//            {
//                return this.typeField;
//            }
//            set
//            {
//                this.typeField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string typeview
//        {
//            get
//            {
//                return this.typeviewField;
//            }
//            set
//            {
//                this.typeviewField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string viewonly
//        {
//            get
//            {
//                return this.viewonlyField;
//            }
//            set
//            {
//                this.viewonlyField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string negative_value_enable
//        {
//            get
//            {
//                return this.negative_value_enableField;
//            }
//            set
//            {
//                this.negative_value_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public bool add_enable
//        {
//            get
//            {
//                return this.add_enableField;
//            }
//            set
//            {
//                this.add_enableField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlIgnoreAttribute()]
//        public bool add_enableSpecified
//        {
//            get
//            {
//                return this.add_enableFieldSpecified;
//            }
//            set
//            {
//                this.add_enableFieldSpecified = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldTitles
//    {

//        private ProfileFastStockInventoryItemsConfigurationFieldTitlesTitle titleField;

//        private ProfileFastStockInventoryItemsConfigurationFieldTitlesDescription descriptionField;

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldTitlesTitle Title
//        {
//            get
//            {
//                return this.titleField;
//            }
//            set
//            {
//                this.titleField = value;
//            }
//        }

//        /// <remarks/>
//        public ProfileFastStockInventoryItemsConfigurationFieldTitlesDescription Description
//        {
//            get
//            {
//                return this.descriptionField;
//            }
//            set
//            {
//                this.descriptionField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldTitlesTitle
//    {

//        private string enField;

//        private string heField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string he
//        {
//            get
//            {
//                return this.heField;
//            }
//            set
//            {
//                this.heField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileFastStockInventoryItemsConfigurationFieldTitlesDescription
//    {

//        private string enField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string en
//        {
//            get
//            {
//                return this.enField;
//            }
//            set
//            {
//                this.enField = value;
//            }
//        }
//    }

//    /// <remarks/>
//    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
//    public partial class ProfileCustomer
//    {

//        private string nameField;

//        private string codeField;

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string name
//        {
//            get
//            {
//                return this.nameField;
//            }
//            set
//            {
//                this.nameField = value;
//            }
//        }

//        /// <remarks/>
//        [System.Xml.Serialization.XmlAttributeAttribute()]
//        public string code
//        {
//            get
//            {
//                return this.codeField;
//            }
//            set
//            {
//                this.codeField = value;
//            }
//        }
//    }


//}
