namespace laba_2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            выходToolStripMenuItem = new ToolStripMenuItem();
            фигурыToolStripMenuItem = new ToolStripMenuItem();
            добавитьToolStripMenuItem = new ToolStripMenuItem();
            переместитьToolStripMenuItem = new ToolStripMenuItem();
            прямоугольникToolStripMenuItem = new ToolStripMenuItem();
            эллипсToolStripMenuItem = new ToolStripMenuItem();
            очиститьToolStripMenuItem = new ToolStripMenuItem();
            panelPaint = new MyPanel();
            labelFactory = new Label();
            comboBoxFactory = new ComboBox();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, фигурыToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.Size = new Size(914, 33);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { выходToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(69, 29);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            выходToolStripMenuItem.Size = new Size(166, 34);
            выходToolStripMenuItem.Text = "Выход";
            выходToolStripMenuItem.Click += ExitToolStripMenuItem_Click;
            // 
            // фигурыToolStripMenuItem
            // 
            фигурыToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { добавитьToolStripMenuItem, очиститьToolStripMenuItem });
            фигурыToolStripMenuItem.Name = "фигурыToolStripMenuItem";
            фигурыToolStripMenuItem.Size = new Size(91, 29);
            фигурыToolStripMenuItem.Text = "Фигуры";
            // 
            // добавитьToolStripMenuItem
            // 
            добавитьToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { переместитьToolStripMenuItem, прямоугольникToolStripMenuItem, эллипсToolStripMenuItem });
            добавитьToolStripMenuItem.Image = Properties.Resources.plus;
            добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
            добавитьToolStripMenuItem.Size = new Size(192, 34);
            добавитьToolStripMenuItem.Text = "Добавить";
            // 
            // переместитьToolStripMenuItem
            // 
            переместитьToolStripMenuItem.Image = Properties.Resources.play;
            переместитьToolStripMenuItem.Name = "переместитьToolStripMenuItem";
            переместитьToolStripMenuItem.Size = new Size(245, 34);
            переместитьToolStripMenuItem.Text = "Переместить";
            // 
            // прямоугольникToolStripMenuItem
            // 
            прямоугольникToolStripMenuItem.Image = Properties.Resources.circle_small;
            прямоугольникToolStripMenuItem.Name = "прямоугольникToolStripMenuItem";
            прямоугольникToolStripMenuItem.Size = new Size(245, 34);
            прямоугольникToolStripMenuItem.Text = "Прямоугольник";
            // 
            // эллипсToolStripMenuItem
            // 
            эллипсToolStripMenuItem.Image = Properties.Resources.square;
            эллипсToolStripMenuItem.Name = "эллипсToolStripMenuItem";
            эллипсToolStripMenuItem.Size = new Size(245, 34);
            эллипсToolStripMenuItem.Text = "Эллипс";
            // 
            // очиститьToolStripMenuItem
            // 
            очиститьToolStripMenuItem.Image = Properties.Resources.trash;
            очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            очиститьToolStripMenuItem.Size = new Size(192, 34);
            очиститьToolStripMenuItem.Text = "Очистить";
            // 
            // panelPaint
            // 
            panelPaint.BackColor = Color.Pink;
            panelPaint.BorderStyle = BorderStyle.FixedSingle;
            panelPaint.Location = new Point(12, 80);
            panelPaint.Margin = new Padding(3, 4, 3, 4);
            panelPaint.Name = "panelPaint";
            panelPaint.Size = new Size(890, 439);
            panelPaint.TabIndex = 1;
            panelPaint.Paint += PaintPanel;
            // 
            // labelFactory
            // 
            labelFactory.AutoSize = true;
            labelFactory.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            labelFactory.Location = new Point(12, 42);
            labelFactory.Name = "labelFactory";
            labelFactory.Size = new Size(104, 28);
            labelFactory.TabIndex = 2;
            labelFactory.Text = "Фабрика:";
            // 
            // comboBoxFactory
            // 
            comboBoxFactory.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFactory.FormattingEnabled = true;
            comboBoxFactory.Items.AddRange(new object[] { "Случайная фабрика", "Поочередная фабрика" });
            comboBoxFactory.Location = new Point(122, 40);
            comboBoxFactory.Name = "comboBoxFactory";
            comboBoxFactory.Size = new Size(200, 33);
            comboBoxFactory.TabIndex = 3;
            comboBoxFactory.SelectedIndexChanged += ComboBoxFactory_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 532);
            Controls.Add(comboBoxFactory);
            Controls.Add(labelFactory);
            Controls.Add(panelPaint);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Графический редактор";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem выходToolStripMenuItem;
        private ToolStripMenuItem фигурыToolStripMenuItem;
        private ToolStripMenuItem добавитьToolStripMenuItem;
        private ToolStripMenuItem переместитьToolStripMenuItem;
        private ToolStripMenuItem прямоугольникToolStripMenuItem;
        private ToolStripMenuItem эллипсToolStripMenuItem;
        private ToolStripMenuItem очиститьToolStripMenuItem;
        private MyPanel panelPaint;
        private Label labelFactory;
        private ComboBox comboBoxFactory;
    }
}