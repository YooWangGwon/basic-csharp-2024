namespace schedule_app
{
    partial class ShowUndo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowUndo));
            panel1 = new Panel();
            listView1 = new ListView();
            ClhTodo = new ColumnHeader();
            ClhDate = new ColumnHeader();
            ClhPlace = new ColumnHeader();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(listView1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 350);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { ClhTodo, ClhDate, ClhPlace });
            listView1.Location = new Point(12, 27);
            listView1.Name = "listView1";
            listView1.Size = new Size(606, 279);
            listView1.TabIndex = 1;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // ClhTodo
            // 
            ClhTodo.Text = "업무";
            ClhTodo.Width = 300;
            // 
            // ClhDate
            // 
            ClhDate.Text = "날짜";
            ClhDate.Width = 150;
            // 
            // ClhPlace
            // 
            ClhPlace.Text = "장소";
            ClhPlace.Width = 150;
            // 
            // ShowUndo
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(630, 350);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "ShowUndo";
            Text = "미완료 업무 목록";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private ListView listView1;
        private ColumnHeader ClhTodo;
        private ColumnHeader ClhDate;
        private ColumnHeader ClhPlace;
    }
}