using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ServerControl1
{  
    [ParseChildrenAttribute(false)]
    [PersistChildrenAttribute(true)]
    [ToolboxData("<{0}:TabBar runat=server></{0}:TabBar>")]
    public class TabBar : WebControl, INamingContainer
    {
        #region construktor
        public TabBar() : base(HtmlTextWriterTag.Div) { }
        #endregion construktor

        #region fields
        private readonly TabWithDelCollection m_tabswithdel = new TabWithDelCollection();
        private readonly ContentCollection m_contents = new ContentCollection();
        #endregion fields

        #region properties
        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public TabWithDelCollection TabWithDelButtons
        {
            get
            {
                return this.m_tabswithdel;
            }
        } 

        [Bindable(false)]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public ContentCollection Contents
        {
            get
            {
                return this.m_contents;
            }
        }

         private int _wd;
       
         [Browsable(true)]
         public int WD {
             get { return _wd; }
             set { _wd = value; }
         }

         private static int _tabcount;

         [Browsable(true)]
         public int TabCount
         {
             get { return _tabcount; }
             set { _tabcount = value; }
         }
        #endregion properties

        #region methods       
        
        #endregion methods
    }

    public class TabWithDelCollection : List<TabButtonWithDelimiter>, INamingContainer
    {
        #region construktor
        public TabWithDelCollection() { }
        #endregion construktor

        #region fields
        private readonly Control IWC10 = new TabButtonWithDelimiter();       
        #endregion fields

        #region properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Control InnerProperty_10
        {
            get { return IWC10; }
        }
        #endregion properties
    }

    public class ContentCollection : List<TabContent>, INamingContainer
    {
        #region construktor
        public ContentCollection() { }
        #endregion construktor

        #region fields
        private readonly Control IWC2 = new TabContent();
        #endregion fields

        #region properties
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public Control InnerProperty_2
        {
            get { return IWC2; }
        }
        #endregion properties
    }
  
    public class TabButtonWithDelimiter : WebControl
    {
        #region construktor
        public TabButtonWithDelimiter() : base(HtmlTextWriterTag.Div) { }
        #endregion construktor

        #region fields
        private bool _IsActive;
        private string _ButtonText;
        private int _Delimiter_Width;//=10;
        #endregion fields

        #region properties
        public bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }
        public string ButtonText
        {
            get { return _ButtonText; }
            set { _ButtonText = value; }
        }

        [Browsable(false)]
        public int DelimiterWidth
        {
            get { return _Delimiter_Width; }
            set { _Delimiter_Width = value; }
        }
        #endregion properties

        #region methods
        protected override void CreateChildControls()
        {
            this.Controls.Add(new TabButton(this));//
            this.Controls.Add(new TabsDelimiter(this));

            base.CreateChildControls();
        }

        protected override void OnPreRender(EventArgs e)
        {
            this.DelimiterWidth = new TabBar().WD;
            base.OnPreRender(e);
        }

        #endregion methods

        #region nested classes
        /// <summary>
        /// Кнопка
        /// </summary>
        public class TabButton : WebControl
        {
            private TabButtonWithDelimiter parent;//Для получения доступа к родительскому классу https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/nested-types
            
            public TabButton(TabButtonWithDelimiter parent) : base(HtmlTextWriterTag.Div)//Для получения доступа к родительскому классу
            {
                this.parent = parent;
            }

            #region fields
            //Класс не содержит переменных
            #endregion fields

            #region properties
            public bool IsActive
            {
                get { return parent.IsActive; }
                set { parent.IsActive = value; }
            }
            public string ButtonText
            {
                get { return parent.ButtonText; }
                set { parent.ButtonText= value; }
            }
            #endregion

            #region methods
            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void AddAttributesToRender(HtmlTextWriter writer)
            {
                if (this.IsActive)
                {
                    writer.AddStyleAttribute("position", "relative");
                    writer.AddStyleAttribute("float", "left");
                    writer.AddStyleAttribute("height", "35px");
                    writer.AddStyleAttribute("width", "125px");
                    writer.AddStyleAttribute("border-left", "solid 1px gray");
                    writer.AddStyleAttribute("border-top", "solid 4px gray");
                    writer.AddStyleAttribute("border-right", "solid 1px gray");
                    writer.AddStyleAttribute("border-bottom", "1px solid white");
                    writer.AddStyleAttribute("text-align", "center");
                    writer.AddStyleAttribute("cursor", "pointer");
                    writer.AddStyleAttribute("background-color", "White");
                    writer.AddStyleAttribute("border-radius", "5px 5px 0 0");
                }
                else
                {
                    writer.AddStyleAttribute("position", "relative");
                    writer.AddStyleAttribute("float", "left");
                    writer.AddStyleAttribute("height", "35px");
                    writer.AddStyleAttribute("width", "125px");
                    writer.AddStyleAttribute("border-left", "solid 1px gray");
                    writer.AddStyleAttribute("border-top", "solid 4px gray");
                    writer.AddStyleAttribute("border-right", "solid 1px gray");
                    writer.AddStyleAttribute("border-bottom", "1px solid white");
                    writer.AddStyleAttribute("text-align", "center");
                    writer.AddStyleAttribute("cursor", "pointer");
                    writer.AddStyleAttribute("background-color", "gray");
                    writer.AddStyleAttribute("border-radius", "5px 5px 0 0");
                }
                writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "changeState('1', 7, this.id, 'vtb_tab', 'content'), setCookie('MyCookieForVTabBar1', this.id)");

                base.AddAttributesToRender(writer);
            }

            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void RenderContents(HtmlTextWriter writer)
            {
                if (this.IsActive)
                {
                    writer.Write("<p style=" + "'position: relative; bottom: 20%; color: darkcyan;'>" + this.ButtonText + "</p>");
                }
                else
                {
                    writer.Write("<p style=" + "'position: relative; bottom: 20%; color: white;'>" + this.ButtonText + "</p>");
                }
                base.RenderContents(writer);
            }
            #endregion methods
        }

        /// <summary>
        /// Разделитель кнопок
        /// </summary>
        public class TabsDelimiter : WebControl
        { 
            #region fields
            private TabButtonWithDelimiter parent;//Для получения доступа к родительскому классу https://docs.microsoft.com/ru-ru/dotnet/csharp/programming-guide/classes-and-structs/nested-types
            #endregion fields
  
            #region properties
            public TabsDelimiter(TabButtonWithDelimiter parent) : base(HtmlTextWriterTag.Div)//Для получения доступа к родительскому класс
            {
                this.parent = parent;
            }

            public int DelimiterWidth
            {
                get { return parent.DelimiterWidth; }
                set { parent.DelimiterWidth = value; }
            }
            #endregion properties

            #region methods
            [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
            protected override void AddAttributesToRender(HtmlTextWriter writer)
            {
                writer.AddStyleAttribute("height", "35px");
                writer.AddStyleAttribute("float", "left");
                writer.AddStyleAttribute("width", this.DelimiterWidth.ToString()+"px");
                writer.AddStyleAttribute("border-bottom", "solid 1px black");
                writer.AddStyleAttribute("border-left", "none");
                writer.AddStyleAttribute("border-right", "none");
                writer.AddStyleAttribute("border-top", "solid 4px transparent");
                base.AddAttributesToRender(writer);
            }
            #endregion methods
        }
        #endregion nested classes
    }

    public class TabContent : WebControl
    {
        #region construktor
        public TabContent() : base(HtmlTextWriterTag.Div) { }
        #endregion construktor
    }  
}