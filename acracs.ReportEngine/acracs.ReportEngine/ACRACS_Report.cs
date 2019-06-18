using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using acschedule;
using PdfSharp;
using PdfSharp.Pdf;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Shapes;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace acracs.ReportEngine
{
    public class ACRACS_Report
    {
        // contructor
        public ACRACS_Report()
        {
            school_Classes = new List<School_Class>();
            reports_Classroooms = new List<ClassRoomReport>();
            reports_Instructors = new List<InstructorReport>();
            reports_Sections = new List<SectionReport>();
            _section = new MigraDoc.DocumentObjectModel.Section();
            _doc_classroom = new Document();
            _doc_instructor = new Document();
            _doc_section = new Document();
            renderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
        }

        // fields
        private Document _doc_classroom;
        private Document _doc_instructor;
        private Document _doc_section;
        private MigraDoc.DocumentObjectModel.Section _section;
        private PdfDocumentRenderer renderer;

        private List<acschedule.School_Class> school_Classes;
        private List<ClassRoomReport> reports_Classroooms;
        private List<InstructorReport> reports_Instructors;
        private List<SectionReport> reports_Sections;

        // properties
        public List<acschedule.School_Class> SchoolClasses
        {
            get
            {
                return this.school_Classes;
            }
            set
            {
                this.school_Classes = value;
            }
        }
        public List<ClassRoomReport> Reports_ClassRooms
        {
            get
            {
                return this.reports_Classroooms;
            }
            set
            {
                this.reports_Classroooms = value;
            }
        }
        public List<InstructorReport> Reports_Instructors
        {
            get
            {
                return this.reports_Instructors;
            }
            set
            {
                this.reports_Instructors = value;
            }
        }
        public List<SectionReport> Reports_Sections
        {
            get
            {
                return this.reports_Sections;
            }
            set
            {
                this.reports_Sections = value;
            }
        }

        //
        // Methods
        //
        // merger
        public void MergeAllReport_Section()
        {
            for (int i = 0; i < reports_Sections.Count; i++)
            {
                _doc_section.Sections.Add(reports_Sections[i].GetSection());
            }
        }
        public void MergeAllReport_Instructor()
        {
            for (int i = 0; i < reports_Instructors.Count; i++)
            {
                _doc_instructor.Sections.Add(reports_Instructors[i].GetSection());
            }
        }
        public void MergeAllReport_Classroom()
        {
            for (int i = 0; i < reports_Classroooms.Count; i++)
            {
                _doc_classroom.Sections.Add(reports_Classroooms[i].GetSection());
            }
        }

        // saver
        public void SaveAllReport_Section(string Path)
        {
            renderer.Document = _doc_section;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path);
        }
        public void SaveAllReport_Instructor(string Path)
        {
            renderer.Document = _doc_instructor;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path);
        }
        public void SaveAllReport_Classroom(string Path)
        {
            renderer.Document = _doc_classroom;
            renderer.RenderDocument();
            renderer.PdfDocument.Save(Path);
        }
    }

    public class SectionReport : SchoolReport
    {
        public SectionReport(string SectionName, int YearLevel)
        {
            this.sectionName = SectionName;
            this.HasWeekEnd = false;

            switch (YearLevel)
            {
                case 1:
                    this.yearLevel = "1st year";
                    break;
                case 2:
                    this.yearLevel = "2nd year";
                    break;
                case 3:
                    this.yearLevel = "3rd year";
                    break;
                case 4:
                    this.yearLevel = "4th year";
                    break;
                case 5:
                    this.yearLevel = "5th year";
                    break;
                default:
                    this.yearLevel = "4th year";
                    break;
            }

            this._Doc = new Document();
            this._Section = new MigraDoc.DocumentObjectModel.Section();
            this._Tbl = new Table();
            this._P = new Paragraph();
            this._Img = new Image();
            this._Renderer = new PdfDocumentRenderer();

            this._Renderer.Document = this._Doc;
        }

        public SectionReport(string SectionName, int YearLevel, bool HasWeekEnd)
        {
            this.sectionName = SectionName;
            this.HasWeekEnd = HasWeekEnd;

            switch (YearLevel)
            {
                case 1:
                    this.yearLevel = "1st year";
                    break;
                case 2:
                    this.yearLevel = "2nd year";
                    break;
                case 3:
                    this.yearLevel = "3rd year";
                    break;
                case 4:
                    this.yearLevel = "4th year";
                    break;
                case 5:
                    this.yearLevel = "5th year";
                    break;
                default:
                    this.yearLevel = "4th year";
                    break;
            }

        }

        // Private fields.
        private string sectionName;
        private string yearLevel;

        //
        // Public methods.
        //

        /// <summary>
        /// Add header text: department
        /// </summary>
        /// <param name="DeptName"></param>
        public void AddHeaderText_Department(string DeptName)
        {
            this._P = this._Section.AddParagraph(DeptName);
            this._P.Format.Font.Bold = true;
            this._P.Format.Alignment = ParagraphAlignment.Center;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 12;
        }
        /// <summary>
        /// Add header text: section name
        /// </summary>
        /// <param name="SectionName"></param>
        public void AddHeaderText_Section(string SectionName)
        {
            this._P = this._Section.AddParagraph(string.Concat("SECTION: ", SectionName));
            this._P.Format.Alignment = ParagraphAlignment.Center;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 12;
            this._P.Format.Font.Bold = true;

            this._P = _Section.AddParagraph("\n\n");
        } 
    }

    public class InstructorReport : SchoolReport
    {
        //
        // Constructors.
        //
        public InstructorReport(string FirstName, string LastName)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.HasWeekEnd = false;

            this._Doc = new Document();
            this._Section = new MigraDoc.DocumentObjectModel.Section();
            this._Tbl = new Table();
            this._P = new Paragraph();
            this._Img = new Image();
            this._Renderer = new PdfDocumentRenderer();

            this._Renderer.Document = this._Doc;
        }
        public InstructorReport(string FirstName, string LastName, bool HasWeekEnd)
        {
            this.firstName = FirstName;
            this.lastName = LastName;
            this.HasWeekEnd = HasWeekEnd;

            this._Doc = new Document();
            this._Section = new MigraDoc.DocumentObjectModel.Section();
            this._Tbl = new Table();
            this._P = new Paragraph();
            this._Img = new Image();
            this._Renderer = new PdfDocumentRenderer();

            this._Renderer.Document = this._Doc;
        }

        // Private fields.
        private string firstName;
        private string lastName;

        //
        // Methods.
        //

        /// <summary>
        /// Add header text: department
        /// </summary>
        /// <param name="DeptName"></param>
        public void AddHeaderText_Department(string DeptName)
        {
            this._P = this._Section.AddParagraph(DeptName);
            this._P.Format.Font.Bold = true;
            this._P.Format.Alignment = ParagraphAlignment.Center;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 12;
        }
        /// <summary>
        /// Add header text: instructor name
        /// </summary>
        public void AddHeaderText_Instructor()
        {
            this._P = this._Section.AddParagraph(string.Concat("INSTRUCTOR: ", this.firstName, ' ', this.lastName));
            this._P.Format.Alignment = ParagraphAlignment.Center;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 12;
            this._P = this._Section.AddParagraph("\n");

            this._P = this._Section.AddParagraph("# of preps:");
            this._P.Format.Alignment = ParagraphAlignment.Right;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 9;
            this._P = this._Section.AddParagraph("\n");
        }
    }

    public class ClassRoomReport : SchoolReport
    { 
        //
        // Constructors.
        //
        public ClassRoomReport(string RoomName)
        {
            this.roomName = RoomName;
            this.HasWeekEnd = false;

            this._Doc = new Document();
            this._Section = new MigraDoc.DocumentObjectModel.Section();
            this._Tbl = new Table();
            this._P = new Paragraph();
            this._Img = new Image();
            this._Renderer = new PdfDocumentRenderer();

            this._Renderer.Document = this._Doc;
        }

        public ClassRoomReport(string RoomName, bool HasWeekEnd)
        {
            this.roomName = RoomName;
            this.HasWeekEnd = HasWeekEnd;

            this._Doc = new Document();
            this._Section = new MigraDoc.DocumentObjectModel.Section();
            this._Tbl = new Table();
            this._P = new Paragraph();
            this._Img = new Image();
            this._Renderer = new PdfDocumentRenderer();

            this._Renderer.Document = this._Doc;
        }
        
        // Private fields.
        private string roomName;

        //
        // Public methods.
        //

        /// <summary>
        /// Add header text: room name
        /// </summary>
        public void AddHeaderText_RoomName()
        {
            this._P = this._Section.AddParagraph(this.roomName);
            this._P.Format.Alignment = ParagraphAlignment.Center;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 12;
            this._P.Format.Font.Bold = true;

            this._P = this._Section.AddParagraph("\n\n");
        }
        /// <summary>
        /// Add header text: room name (with parameters)
        /// </summary>
        /// <param name="New_RoomName"></param>
        public void AddHeaderText_RoomName(string New_RoomName)
        {
            this.roomName = New_RoomName;

            this._P = this._Section.AddParagraph(this.roomName);
            this._P.Format.Alignment = ParagraphAlignment.Center;
            this._P.Format.Font.Name = "Arial";
            this._P.Format.Font.Size = 12;
            this._P.Format.Font.Bold = true;

            this._P = this._Section.AddParagraph("\n\n");
        }
    }

    public class SchoolReport
    {
        public SchoolReport()
        {
            _section = new MigraDoc.DocumentObjectModel.Section();
            _doc = new Document();
            _renderer = new PdfDocumentRenderer(false, PdfFontEmbedding.Always);
            _renderer.Document = _doc;
        }

        // Private fields. (Accessible only in the class itself.)
        private MigraDoc.DocumentObjectModel.Section _section; // section or page
        private Paragraph _p;
        private Image _img;
        private Table _tbl;
        private Document _doc;
        private PdfDocumentRenderer _renderer;

        // Private fields with public properties
        private bool hasWeekEnd;

        // Public property. (1)
        public bool HasWeekEnd
        {
            get {
                return this.hasWeekEnd;
            }
            set {
                this.hasWeekEnd = true;
            }
        }
        // Internal properties
        internal MigraDoc.DocumentObjectModel.Section _Section
        {
            get {
                return this._section;
            }
            set {
                this._section = value;
            }
        }
        internal Paragraph _P
        {
            get {
                return this._p;
            }
            set {
                this._p = value;
            }
        }
        internal Image _Img
        {
            get {
                return this._img;
            }
            set {
                this._img = value;
            }
        }
        internal Table _Tbl
        {
            get {
                return this._tbl;
            }
            set {
                this._tbl = value;
            }
        }
        internal Document _Doc
        {
            get {
                return this._doc;
            }
            set {
                this._doc = value;
            }
        }
        internal PdfDocumentRenderer _Renderer
        {
            get {
                return this._renderer;
            }
            set {
                this._renderer = value;
            }
        }

        //
        // All Public Methods.
        //


        public void AddNewPage()
        {
            this._section = _doc.AddSection();
        }
        /// <summary>
        /// Add logo to the report. The logo will be placed on the header of the report.
        /// </summary>
        /// <param name="Path"></param>
        public void AddLogo(string Path)
        {
            _img = _section.AddImage(Path);
            _img.LockAspectRatio = true;
            _img.Top = ShapePosition.Center;
            _img.Left = ShapePosition.Center;
        }
        /// <summary>
        /// Add header text: school name
        /// </summary>
        /// <param name="SchoolName"></param>
        /// <param name="Location"></param>
        public void AddHeaderText_SchoolName(string SchoolName, string Location)
        {
            _p = _section.AddParagraph(SchoolName);
            _p.Format.Alignment = ParagraphAlignment.Center;
            _p.Format.Font.Name = "Calibri";
            _p.Format.Font.Size = 11;

            _p = _section.AddParagraph(Location);
            _p.Format.Alignment = ParagraphAlignment.Center;
            _p.Format.Font.Name = "Calibri";
            _p.Format.Font.Size = 11;
        }
        /// <summary>
        /// Create a report table. This is the containing table to draw/visualize the class in the report document.
        /// </summary>
        public void Create_ReportTable()
        {
            _tbl = _section.AddTable();
            _tbl.Rows.Alignment = RowAlignment.Center;
            _tbl.Format.Font.Size = 11;
            _tbl.Borders.Color = Colors.Black;

            // Add columns
            _tbl.AddColumn(new Unit(.60, UnitType.Inch));
            _tbl.AddColumn(new Unit(.60, UnitType.Inch));

            // determine if report has saturday/sunday classes
            if (this.hasWeekEnd)
            {
                for (int i = 0; i < 7; i++)
                {
                    _tbl.AddColumn(new Unit(1.00, UnitType.Inch));
                }
            }
            else
            {
                // if no saturday/sunday classes
                for (int i = 0; i < 5; i++)
                {
                    _tbl.AddColumn(new Unit(1.25, UnitType.Inch));
                }
            }

            // Add rows
            _tbl.AddRow();
            _tbl.AddRow();

            _tbl.Rows[0].Cells[0].MergeRight = 1;

            if (this.hasWeekEnd)
            {
                _tbl.Rows[0].Cells[2].MergeRight = 6;
            }
            else
            {
                _tbl.Rows[0].Cells[2].MergeRight = 4;
            }

            // Add text to table headers
            _tbl.Rows[0].TopPadding = new Unit(.05, UnitType.Inch);
            _tbl.Rows[0].BottomPadding = new Unit(.05, UnitType.Inch);

            _tbl.Format.Font.Name = "Arial Narrow";
            _tbl.Format.Font.Size = 10;
            _p = _tbl.Rows[0].Cells[0].AddParagraph("TIME");
            _p.Format.Font.Bold = true;
            _p.Format.Alignment = ParagraphAlignment.Center;

            _p = _tbl.Rows[0].Cells[2].AddParagraph("DAYS");
            _p.Format.Font.Bold = true;
            _p.Format.Alignment = ParagraphAlignment.Center;

            _p = _tbl.Rows[1].Cells[0].AddParagraph("FROM");
            _p.Format.Font.Bold = true;

            _p = _tbl.Rows[1].Cells[1].AddParagraph("TO");
            _p.Format.Font.Bold = true;

            _p = _tbl.Rows[1].Cells[2].AddParagraph("MONDAY");
            _p.Format.Font.Bold = true;
            _p = _tbl.Rows[1].Cells[3].AddParagraph("TUESDAY");
            _p.Format.Font.Bold = true;
            _p = _tbl.Rows[1].Cells[4].AddParagraph("WEDNESDAY");
            _p.Format.Font.Bold = true;
            _p = _tbl.Rows[1].Cells[5].AddParagraph("THURSDAY");
            _p.Format.Font.Bold = true;
            _p = _tbl.Rows[1].Cells[6].AddParagraph("FRIDAY");
            _p.Format.Font.Bold = true;

            if (this.hasWeekEnd)
            {
                _p = _tbl.Rows[1].Cells[7].AddParagraph("SATURDAY");
                _p.Format.Font.Bold = true;
                _p = _tbl.Rows[1].Cells[8].AddParagraph("SUNDAY");
                _p.Format.Font.Bold = true;
            }


            // Add the time rows (session time)
            for (int i = 1; i <= 34; i++)
            {
                _tbl.AddRow();
            }

            // declare a datetime object
            DateTime timeloader = DateTime.Parse("6:00 AM");
            int counter = 0;

            for (int i = 2; i <= 35; i++)
            {
                _p = _tbl.Rows[i].Cells[0].AddParagraph(timeloader.AddMinutes(counter).ToShortTimeString());
                _p.Format.Alignment = ParagraphAlignment.Right;
                counter += 30;
                _p = _tbl.Rows[i].Cells[1].AddParagraph(timeloader.AddMinutes(counter).ToShortTimeString());
                _p.Format.Alignment = ParagraphAlignment.Right;
            }

            // remove borders in days cells
            for (int i = 2; i <= 35; i++)
            {
                _tbl.Rows[i].Cells[2].Borders.Top.Visible = false;
                _tbl.Rows[i].Cells[2].Borders.Left.Visible = false;
                _tbl.Rows[i].Cells[2].Borders.Bottom.Visible = false;

                _tbl.Rows[i].Cells[3].Borders.Top.Visible = false;
                _tbl.Rows[i].Cells[3].Borders.Left.Visible = false;
                _tbl.Rows[i].Cells[3].Borders.Bottom.Visible = false;

                _tbl.Rows[i].Cells[4].Borders.Top.Visible = false;
                _tbl.Rows[i].Cells[4].Borders.Left.Visible = false;
                _tbl.Rows[i].Cells[4].Borders.Bottom.Visible = false;

                _tbl.Rows[i].Cells[5].Borders.Top.Visible = false;
                _tbl.Rows[i].Cells[5].Borders.Left.Visible = false;
                _tbl.Rows[i].Cells[5].Borders.Bottom.Visible = false;

                _tbl.Rows[i].Cells[6].Borders.Top.Visible = false;
                _tbl.Rows[i].Cells[6].Borders.Left.Visible = false;
                _tbl.Rows[i].Cells[6].Borders.Bottom.Visible = false;

                if (this.hasWeekEnd)
                {
                    _tbl.Rows[i].Cells[7].Borders.Top.Visible = false;
                    _tbl.Rows[i].Cells[7].Borders.Left.Visible = false;
                    _tbl.Rows[i].Cells[7].Borders.Bottom.Visible = false;

                    _tbl.Rows[i].Cells[8].Borders.Top.Visible = false;
                    _tbl.Rows[i].Cells[8].Borders.Left.Visible = false;
                    _tbl.Rows[i].Cells[8].Borders.Bottom.Visible = false;
                }

            }
            _tbl.Rows[35].Cells[2].Borders.Bottom.Visible = true;
            _tbl.Rows[35].Cells[3].Borders.Bottom.Visible = true;
            _tbl.Rows[35].Cells[4].Borders.Bottom.Visible = true;
            _tbl.Rows[35].Cells[5].Borders.Bottom.Visible = true;
            _tbl.Rows[35].Cells[6].Borders.Bottom.Visible = true;

            if (this.hasWeekEnd)
            {
                _tbl.Rows[35].Cells[7].Borders.Bottom.Visible = true;
                _tbl.Rows[35].Cells[8].Borders.Bottom.Visible = true;
            }
        }
        /// <summary>
        /// Add class / Display class in the table with color highlighting. (Method is overridable)
        /// </summary>
        /// <param name="Class">The school class object. (from acschedule library)</param>
        /// <param name="Data1">1st string to display in the report.</param>
        /// <param name="Data2">2nd  string to display in the report.</param>
        /// <param name="Data3">3rd  string to display in the report.</param>
        /// <param name="Highlight">Color highlight of the class.</param>
        public virtual void AddClass(School_Class Class, string Data1, string Data2, string Data3, Color Highlight)
        {
            // Locate the appropriate row number.
            int row = int.Parse((new TimeSpan(Class.Class_TimeStart.Hour - 6, Class.Class_TimeStart.Minute, Class.Class_TimeStart.Second).TotalMinutes / 30).ToString()) + 2;
            // Count the number or rows to be highlighted.
            int time_includes = int.Parse((new TimeSpan(Class.Class_TimeEnd.Hour - Class.Class_TimeStart.Hour, Class.Class_TimeEnd.Minute - Class.Class_TimeStart.Minute, Class.Class_TimeEnd.Second - Class.Class_TimeStart.Second).TotalMinutes / 30).ToString());
            int day = 0;

            // Determine the class day
            switch (Class.Day)
            {
                case "Monday":
                    day = 2;
                    break;
                case "Tuesday":
                    day = 3;
                    break;
                case "Wednesday":
                    day = 4;
                    break;
                case "Thursday":
                    day = 5;
                    break;
                case "Friday":
                    day = 6;
                    break;
                case "Saturday":
                    day = 7;
                    break;
                case "Sunday":
                    day = 8;
                    break;
            }

            // Display the class information (data1, data2).
            _p = _tbl.Rows[row].Cells[day].AddParagraph(string.Concat(Data1, '(', Data2, ')'));
            _p.Format.Font.Size = 9;
            _p.Format.Font.Bold = true;

            // Add shading to the class.
            for (int i = row; i <= row + time_includes - 1; i++)
            {
                _tbl.Rows[i].Cells[day].Shading.Color = Highlight;
            }

            // Display the 3rd data
            _p = _tbl.Rows[row + time_includes - 1].Cells[day].AddParagraph(Data3);
            _p.Format.Font.Size = 8;


        }

        /// <summary>
        /// Generate a new pdf report
        /// </summary>
        public void Render()
        {
            _renderer.RenderDocument();
        }

        /// <summary>
        /// Print method is not yet defined.
        /// </summary>
        public void Print()
        {
        }
        /// <summary>
        /// Save report as pdf file.
        /// </summary>
        /// <param name="Path"></param>
        public void Save(string Path)
        {
            _renderer.PdfDocument.Save(Path);
        }
        /// <summary>
        ///  Returns the section or page.
        /// </summary>
        /// <returns></returns>
        public MigraDoc.DocumentObjectModel.Section GetSection()
        {
            return this._section;
        }

    }
}
