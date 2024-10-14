using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        private enum Shape { Line, Circle, Rectangle }
        private Shape currentShape = Shape.Line;
        private Color currentColor = Color.Black; // Цвет по умолчанию
        private Point startPoint;
        private bool isDrawing;

        // Класс для хранения информации о нарисованных фигурах
        private class DrawnShape
        {
            public Shape ShapeType { get; set; }
            public Color Color { get; set; }
            public Point StartPoint { get; set; }
            public Point EndPoint { get; set; }
        }

        private List<DrawnShape> drawnShapes = new List<DrawnShape>(); // Список нарисованных фигур

        public Form1()
        {
            InitializeComponent();
            panelColor.BackColor = currentColor; // Устанавливаем цвет панели
        }

        private void buttonLine_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Line; // Выбор линии
        }

        private void buttonCircle_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Circle; // Выбор круга
        }

        private void buttonRectangle_Click(object sender, EventArgs e)
        {
            currentShape = Shape.Rectangle; // Выбор прямоугольника
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                currentColor = colorDialog.Color; // Устанавливаем выбранный цвет
                panelColor.BackColor = currentColor; // Обновляем панель
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            startPoint = e.Location;
            isDrawing = true; // Начинаем рисование
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                this.Invalidate(); // Перерисовка формы
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false; // Завершаем рисование
            DrawnShape shape = new DrawnShape
            {
                ShapeType = currentShape,
                Color = currentColor,
                StartPoint = startPoint,
                EndPoint = e.Location
            };

            // Сохраняем нарисованную фигуру
            drawnShapes.Add(shape);

            // Перерисовываем форму
            this.Invalidate();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            using (Pen pen = new Pen(currentColor, 2))
            {
                foreach (var shape in drawnShapes)
                {
                    switch (shape.ShapeType)
                    {
                        case Shape.Line:
                            e.Graphics.DrawLine(pen, shape.StartPoint, shape.EndPoint);
                            break;
                        case Shape.Circle:
                            int diameter = Math.Max(shape.EndPoint.X - shape.StartPoint.X, shape.EndPoint.Y - shape.StartPoint.Y);
                            e.Graphics.DrawEllipse(pen, shape.StartPoint.X, shape.StartPoint.Y, diameter, diameter);
                            break;
                        case Shape.Rectangle:
                            e.Graphics.DrawRectangle(pen, shape.StartPoint.X, shape.StartPoint.Y,
                                shape.EndPoint.X - shape.StartPoint.X, shape.EndPoint.Y - shape.StartPoint.Y);
                            break;
                    }
                }
            }
        }

        private void panelColor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
