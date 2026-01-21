using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

namespace laba_2
{
    public partial class Form1 : Form
    {
        private List<GraphObject> elements = new List<GraphObject>();
        private GraphObject selectedObject = null;
        private GraphObject draggedObject = null;
        private Point dragOffset;
        private bool isDragging = false;

        // Фабрики
        private IGraphicFactory currentFactory;
        private RandomObjectFactory randomFactory = new RandomObjectFactory();
        private TwoTypeFactory twoTypeFactory = new TwoTypeFactory();

        public Form1()
        {
            InitializeComponent();

            GraphObject.MaxSize = panelPaint.ClientSize;

            currentFactory = randomFactory;
            comboBoxFactory.SelectedIndex = 0; 

            comboBoxFactory.SelectedIndexChanged += ComboBoxFactory_SelectedIndexChanged;

            добавитьToolStripMenuItem.Click += AddFigure;
            очиститьToolStripMenuItem.Click += ClearFigures;
            прямоугольникToolStripMenuItem.Click += AddRectangle;
            эллипсToolStripMenuItem.Click += AddEllipse;
            переместитьToolStripMenuItem.Click += MoveSelected;
            выходToolStripMenuItem.Click += ExitToolStripMenuItem_Click;

            panelPaint.MouseDoubleClick += PanelPaint_MouseDoubleClick;
            panelPaint.MouseDown += PanelPaint_MouseDown;
            panelPaint.MouseMove += PanelPaint_MouseMove;
            panelPaint.MouseUp += PanelPaint_MouseUp;

            this.Resize += Form1_Resize;
        }
     
        public void PaintPanel(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);

            // Рисуем все объекты
            foreach (GraphObject elem in elements)
            {
                elem.Draw(e.Graphics);
            }

            if (isDragging && draggedObject != null)
            {
                using (Brush transparentBrush = new SolidBrush(Color.FromArgb(128,
                    draggedObject.GetType() == typeof(Rectangle) ? Color.Purple : Color.DarkViolet)))
                {
                    if (draggedObject is Rectangle rect)
                    {
                        e.Graphics.FillRectangle(transparentBrush, rect.X, rect.Y,
                                                rect.GetWidth(), rect.GetHeight());
                    }
                    else if (draggedObject is Ellipse ellipse)
                    {
                        e.Graphics.FillEllipse(transparentBrush, ellipse.X, ellipse.Y,
                                              ellipse.GetWidth(), ellipse.GetHeight());
                    }
                }
            }
        }

        private void AddFigure(object sender, EventArgs e)
        {
            try
            {
                GraphObject obj = currentFactory.CreateGraphObject();
                elements.Add(obj);
                panelPaint.Invalidate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddRectangle(object sender, EventArgs e)
        {
            try
            {
                elements.Add(new Rectangle());
                panelPaint.Invalidate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddEllipse(object sender, EventArgs e)
        {
            try
            {
                elements.Add(new Ellipse());
                panelPaint.Invalidate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearFigures(object sender, EventArgs e)
        {
            elements.Clear();
            selectedObject = null;
            draggedObject = null;
            isDragging = false;
            panelPaint.Invalidate();
        }

        private void MoveSelected(object sender, EventArgs e)
        {
            if (selectedObject != null)
            {
                try
                {
                    Random rnd = new Random();
                    selectedObject.X += rnd.Next(-20, 21);
                    selectedObject.Y += rnd.Next(-20, 21);
                    panelPaint.Invalidate();
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PanelPaint_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                GraphObject obj = currentFactory.CreateGraphObject();

                if (obj is Rectangle rect)
                {
                    rect.X = e.X - rect.GetWidth() / 2;
                    rect.Y = e.Y - rect.GetHeight() / 2;
                }
                else if (obj is Ellipse ellipse)
                {
                    ellipse.X = e.X - ellipse.GetWidth() / 2;
                    ellipse.Y = e.Y - ellipse.GetHeight() / 2;
                }

                elements.Add(obj);
                panelPaint.Invalidate();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PanelPaint_MouseDown(object sender, MouseEventArgs e)
        {
            draggedObject = null;
            isDragging = false;

            for (int i = elements.Count - 1; i >= 0; i--)
            {
                if (elements[i].ContainsPoint(new Point(e.X, e.Y)))
                {
                    draggedObject = elements[i];
                    break;
                }
            }

            if (draggedObject != null)
            {
                dragOffset = new Point(e.X - draggedObject.X, e.Y - draggedObject.Y);
                isDragging = true;

                if (selectedObject != null && selectedObject != draggedObject)
                {
                    selectedObject.Selected = false;
                }
                selectedObject = draggedObject;
                selectedObject.Selected = true;

                panelPaint.Invalidate();
                panelPaint.Cursor = Cursors.SizeAll;
            }
            else
            {
                if (selectedObject != null)
                {
                    selectedObject.Selected = false;
                    selectedObject = null;
                    panelPaint.Invalidate();
                }
            }
        }

        private void PanelPaint_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedObject != null)
            {
                try
                {
                    int newX = e.X - dragOffset.X;
                    int newY = e.Y - dragOffset.Y;

                  //  if (newX >= 0 && newX + draggedObject.GetWidth() <= panelPaint.Width &&
                    //    newY >= 0 && newY + draggedObject.GetHeight() <= panelPaint.Height)
                    {
                        draggedObject.X = newX;
                        draggedObject.Y = newY;
                        panelPaint.Invalidate();
                    }
                }
                catch (ArgumentException)
                {
                    // Игнорируем ошибки при перемещении за границы
                }
            }
        }

        private void PanelPaint_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedObject != null)
            {
                try
                {
                    draggedObject.X = e.X - dragOffset.X;
                    draggedObject.Y = e.Y - dragOffset.Y;
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка перемещения",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            isDragging = false;
            draggedObject = null;
            panelPaint.Cursor = Cursors.Default;
            panelPaint.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (panelPaint != null)
            {
                GraphObject.MaxSize = panelPaint.ClientSize;
                panelPaint.Invalidate();
            }
        }

        private void ComboBoxFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFactory.SelectedIndex == 0)
                currentFactory = randomFactory;
            else if (comboBoxFactory.SelectedIndex == 1)
                currentFactory = twoTypeFactory;
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}