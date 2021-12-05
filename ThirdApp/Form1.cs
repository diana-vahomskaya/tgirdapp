using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThirdApp
{
    public partial class Form1 : Form
    {
        double U0;
        double koef; // коэффициент наклона энергии в яме
        int k_dlg; // номер стационарного уровня, введеный с экрана
        double R; // интервал z
        double a; // ширина ямы
        double Emin, Emax; // интервал энергий
        double[] Psi; // для волновой функции
        double[] Fi; // для фазовой функции
        double[] r; // для радиальной функции 
        double[] lastFi; // для фазовой функции на "другом" конце
        double Sigma;
        Graphics grFi, grPsi;
        Pen pen, pen_markup, pen_line;
        Font m_font;
        SolidBrush m_brush_text;

        private void DRAW_Click(object sender, EventArgs e)
        {
            InitValues();
            int count = 300; // количество точек в графике и элементов для вычисления

            Fi = new double[count];
            lastFi = new double[count];
            r = new double[count];
            Psi = new double[count];

            Emin = 0; // минимум энергии 
            Emax = koef * a; // максимум энергии

            int k = 0; // количество стационарных состояний

            double currentFi = -Math.PI / 2; // текущее значение фи
            double currentE = Emin; // текущее значение энергии

            // зададим начальное значение для фи на "другом" конце
            lastFi[0] = GetFi(currentE, count);

            // создадим список для стационарных состояний,
            // будем туда записывать значения энергии
            List<double> Est = new List<double>();
            Est.Clear();

            // считаем фи на "другом" конце, считаем количество стационарных состояний
            for (int i = 1; i < count; i++)
            {
                currentE = Emin + ((Emax - Emin) / count) * i;
                lastFi[i] = GetFi(currentE, count);
                if (lastFi[i] < currentFi && lastFi[i - 1] > currentFi)
                {
                    k++;

                    // посчитаем значение энергии на данном уровне
                    double Estat = GetEstat(currentE - (Emax - Emin) / count,
                        currentE, lastFi[i - 1], lastFi[i], currentFi, 0.1, count);

                    // запишем значение в список
                    Est.Insert(Est.Count, Estat);

                    // изменим уровень, будем искать пересечение
                    // со следующим уровнем(горизонтальной линией)
                    currentFi = -(2 * k + 1) * Math.PI / 2;
                }
            }
            textBox4.Text = Convert.ToString(k);

            if (k_dlg > 0 && k_dlg <= k)
            {
                // находим радиальную функцию
                r = Get_r(Est.ElementAt((int)k_dlg - 1), count);

                // находим фазовую функцию
                GetFi(Est.ElementAt((int)k_dlg - 1), count);

                // считаем значение волновой функции
                for (int i = 0; i < count; i++)
                {
                    Psi[i] = r[i] * Math.Cos(Fi[i]);
                }

            }
            else
            {
                MessageBox.Show("Недопустимый параметр k, измените значение.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //// рисуем 

            max_y = search_max(lastFi, count);
            min_y = search_min(lastFi, count);
            min_x = 0; max_x = count;

            grFi.Clear(Color.White);
            Draw_Markup(min_x, max_x, min_y, max_y, max_x, (max_y - min_y), 30, 15, true, false, pen_markup, grFi, pictureBox1);
            for (int i = 0; i < k; i++)
            {
                grFi.DrawLine(pen_line,
                    point(min_x, -(2 * i + 1) * Math.PI / 2, min_x, max_x, min_y, max_y, pictureBox1.Height, pictureBox1.Width, 30, 15),
                    point(max_x, -(2 * i + 1) * Math.PI / 2, min_x, max_x, min_y, max_y, pictureBox1.Height, pictureBox1.Width, 30, 15));
                Point pt = point(min_x, -(2 * i + 1) * Math.PI / 2, min_x, max_x, min_y, max_y, pictureBox1.Height, pictureBox1.Width, 30, 15);
                grFi.DrawString(Convert.ToString(Math.Round(-(2 * i + 1) * Math.PI / 2, 2)), m_font, m_brush_text, pt.X - 40, pt.Y - 6);
            }
            Draw_Graph(lastFi, count, min_x, max_x, min_y, max_y, 30, 15, grFi, pictureBox1, pen);

            grPsi.Clear(Color.White);
            if (k_dlg > 0 && k_dlg <= k)
            {
                max_y = search_max(Psi, count);
                min_y = search_min(Psi, count);
                min_x = 0; max_x = count;

                Draw_Markup(min_x, max_x, min_y, max_y, (max_x - min_x) / 4, (max_y - min_y) / 4, 30, 15, true, true, pen_markup, grPsi, pictureBox2);
                Draw_Graph(Psi, count, min_x, max_x, min_y, max_y, 30, 15, grPsi, pictureBox2, pen);
            }

        }

        double min_x, max_x, min_y, max_y;
        public Form1()
        {
            InitializeComponent();
            grFi = pictureBox1.CreateGraphics();
            grFi.Clear(Color.White);
            grPsi = pictureBox2.CreateGraphics();
            grPsi.Clear(Color.White);
            pen_markup = new Pen(Color.Black);
            pen_markup.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            pen = new Pen(Color.Black, 2);
            pen_line = new Pen(Color.Black, 1);
            pen_line.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            m_font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Regular);
            m_brush_text = new SolidBrush(Color.Black);
        }

        void InitValues()
        {
            koef = Convert.ToDouble(TEXT_K.Text);
            k_dlg = Convert.ToInt32(textBox2.Text);
            a = Convert.ToDouble(YAMA.Text);
            R = 15;
            U0 = Convert.ToDouble(TEXT_V.Text);
            Sigma = Convert.ToDouble(TEXT_SIGMA.Text);
        }

        // энергия системы
        double GetU(double koef, double x)
        {
            return (1 / 2 * koef * x * x + (U0 * Math.Exp(-(x * x) / (2 *Sigma* Sigma))) / (Sigma * Math.Pow(2 * Math.PI, 1/2)));
        }

        //уравнение для фи 1 порядка
        double dFi(double energy, double fi, double z)
        {
            return (GetU(koef, z) - energy) * Math.Cos(fi) * Math.Cos(fi) - Math.Sin(fi) * Math.Sin(fi);
        }

        // решение уравнения для фи методом рунге кутта
        double GetFi(double energy, int count)
        {
            double[] mas = new double[count];
            double k1, k2, k3, k4;
            double zStart = -R;
            double zFinal = R;

            int CurIndex = 0;
            double CurZ = 0;
            double dz = (zFinal - zStart) / count;
            mas[CurIndex] = Math.PI / 2;
            Fi[CurIndex] = mas[CurIndex];

            for (int i = 1; i < count; i++)
            {
                CurZ = zStart + i * dz;

                k1 = dFi(energy, mas[CurIndex], CurZ) * dz;
                k2 = dFi(energy, mas[CurIndex] + k1 / 2, CurZ + dz / 2) * dz;
                k3 = dFi(energy, mas[CurIndex] + k2 / 2, CurZ + dz / 2) * dz;
                k4 = dFi(energy, mas[CurIndex] + k3, CurZ + dz) * dz;

                mas[CurIndex + 1] = mas[CurIndex] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                Fi[CurIndex] = mas[CurIndex];

                CurIndex++;
            }

            return mas[count - 1];
        }

        // нахождение энергии - точки пересечения линии стац.состояния и фазовой функции фи
        // используется метод половинного деления
        double GetEstat(double E_min, double E_max, double fi_left, double fi_right,
            double stat_value, double eps, int count)
        {
            double midE;
            double midFi;
            int iter = 0;
            double err;

            do
            {
                midE = (E_max + E_min) / 2;
                midFi = GetFi(midE, count);
                double flag = (fi_left - stat_value) * (midFi - stat_value);

                if (flag < 0)
                {
                    E_max = midE;
                    fi_right = midFi;
                }
                else
                {
                    E_min = midE;
                    fi_left = midFi;
                }
                /*iter++;
                if (iter > 10000)
                {
                    MessageBox.Show("Точность не достигнута за заданное количество итераций, дальнейшие вычисления невозможны.", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                }*/
                err = Math.Abs(midFi - stat_value);
            }
            while (err > eps);

            return midE;
        }

        // уравнения для r 1 порядка
        double dr(double _r, double _U, double _E, double _fi)
        {
            return _r * (_U - _E + 1) * Math.Cos(_fi) * Math.Sin(_fi);
        }

        // нахождение радиальной функции методом рунге кутта
        double[] Get_r(double _E, int count)
        {
            double[] mas = new double[count];

            double zStart = -R;
            double zFinal = R;

            int CurIndex = count / 2;
            double CurZ;
            double dz = (zFinal - zStart) / count;
            double k1, k2, k3, k4;
            mas[CurIndex] = 1;

            for (int i = CurIndex + 1; i < count - 1; i++)
            {
                CurZ = zStart + i * dz;
                GetFi(_E, count);
                k1 = dz * dr(mas[CurIndex], GetU(koef, CurZ), _E, Fi[CurIndex]);
                k2 = dz * dr(mas[CurIndex] + k1 / 2, GetU(koef, CurZ + dz / 2), _E, Fi[CurIndex]);
                k3 = dz * dr(mas[CurIndex] + k2 / 2, GetU(koef, CurZ + dz / 2), _E, Fi[CurIndex]);
                k4 = dz * dr(mas[CurIndex] + k3, GetU(koef, CurZ + dz), _E, Fi[CurIndex]);

                mas[CurIndex + 1] = mas[CurIndex] + (k1 + 2 * k2 + 2 * k3 + k4) / 6;
                CurIndex++;
            }

            dz = -(zFinal - zStart) / count;
            CurIndex = count / 2 - 1;
            mas[CurIndex] = 1;

            for (int i = CurIndex - 1; i >= 0; i--)
            {
                CurZ = zStart - i * dz;
                GetFi(_E, count);
                k1 = dr(mas[CurIndex], GetU(koef, CurZ), _E, Fi[CurIndex]);
                k2 = dr(mas[CurIndex] + k1 * dz / 2, GetU(koef, CurZ + dz / 2), _E, Fi[CurIndex]);
                k3 = dr(mas[CurIndex] + k2 * dz / 2, GetU(koef, CurZ + dz / 2), _E, Fi[CurIndex]);
                k4 = dr(mas[CurIndex] + k3 * dz, GetU(koef, CurZ + dz), _E, Fi[CurIndex]);

                CurIndex--;
                mas[CurIndex] = mas[CurIndex + 1] + (k1 + 2 * k2 + 2 * k3 + k4) * dz / 6;

            }
            return mas;
        }

        double search_min(double[] mas, int n)
        {
            double min = mas[0];
            for (int i = 1; i < n; i++)
            {
                if (mas[i] < min) min = mas[i];
            }
            return min;
        }
        double search_max(double[] mas, int n)
        {
            double max = mas[0];
            for (int i = 1; i < n; i++)
            {
                if (mas[i] > max) max = mas[i];
            }
            return max;
        }

        Point point(
                   double x, double y,
                   double min_x, double max_x,
                   double min_y, double max_y,
                   int height, int width, // высота и ширина окна рисования
                   int x_indent, int y_indent) // отступы
        {
            Point coord = new Point();
            coord.X = (int)((width - 2 * x_indent) * (x - min_x) / (max_x - min_x) + 2 * x_indent - 20);
            coord.Y = (int)((height - 2 * y_indent) * (1 - (y - min_y) / (max_y - min_y)) + 10);
            return coord;
        }

        void Draw_Markup(
            double min_x,
            double max_x,
            double min_y,
            double max_y,
            double x_interval, // интервал между вертикальными линиями
            double y_interval, // интервал между горизонтальными линиями
            int x_indent, // отступ по горизонтали от краев
            int y_indent, // отступ по вертикали от краев
            bool x_label,
            bool y_label,
            Pen pen, // карандаш
            Graphics graph, // объект типа Graphics куда рисовать
            PictureBox picturebox) // объект PictureBox в интерфейсе
        {
            Font font;
            font = new Font(FontFamily.GenericSansSerif, 10.0F, FontStyle.Regular);
            SolidBrush brush_text;
            brush_text = new SolidBrush(Color.Black);
            Point p;
            for (double i = min_x; i <= max_x + x_interval / 10; i += x_interval)
            {
                graph.DrawLine(pen,
                    point(i, min_y, min_x, max_x, min_y, max_y, picturebox.Height, (picturebox.Width), x_indent, y_indent),
                    point(i, max_y, min_x, max_x, min_y, max_y, picturebox.Height, (picturebox.Width), x_indent, y_indent));
                if (x_label)
                {
                    if (i != min_x)
                    {
                        p = point(i, min_y, min_x, max_x, min_y, max_y, picturebox.Height, (picturebox.Width), x_indent, y_indent);
                        p.X -= 8;
                        double ii = i;
                        ii = Math.Round(ii, 2);
                        graph.DrawString(Convert.ToString(ii), font, brush_text, p);
                    }
                }
            }
            for (double i = min_y; i <= max_y + y_interval / 10; i += y_interval)
            {
                Point p1 = point(min_x, i, min_x, max_x, min_y, max_y, picturebox.Height, picturebox.Width, x_indent, y_indent);
                Point p2 = point(max_x, i, min_x, max_x, min_y, max_y, picturebox.Height, picturebox.Width, x_indent, y_indent);
                graph.DrawLine(pen, p1, p2);
                if (y_label)
                {
                    p = point(min_x, i, min_x, max_x, min_y, max_y, picturebox.Height, (picturebox.Width), 0, y_indent);
                    p.Y -= 6;
                    p.X = 0;
                    double ii = i;
                    ii = Math.Round(ii, 2);
                    graph.DrawString(Convert.ToString(ii), font, brush_text, p);
                }
            }

        }
        void Draw_Graph(double[] data, int N, double min_x, double max_x, double min_y, double max_y, int x_indent, int y_indent, Graphics gr, PictureBox picturebox, Pen pen)
        {
            Point p1, p2;
            for (int i = 0; i < N - 1; i++)
            {
                p1 = point(i, data[i], min_x, max_x, min_y, max_y, picturebox.Height, picturebox.Width, x_indent, y_indent);
                p2 = point(i + 1, data[i + 1], min_x, max_x, min_y, max_y, picturebox.Height, picturebox.Width, x_indent, y_indent);
                //gr.DrawLine(pen, p1, p2);
                gr.DrawLine(pen, (float)p1.X, (float)p1.Y, (float)p2.X, (float)p2.Y);
                //gr.DrawEllipse(pen, p1.X, p1.Y, 2, 2);
            }
        }
    }
}
