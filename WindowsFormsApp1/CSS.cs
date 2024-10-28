using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Изменить на иную стилистику(IN PROGRESS Mark)
//public class BeutifulButton : Button
//{
//protected override void OnPaint(PaintEventArgs e)
//{
//    Graphics g = e.Graphics;

//    using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, Color.LightBlue), Color.FromArgb(0, Color.LightBlue), 90f))
//    {
//        g.FillRectangle(brush, ClientRectangle);
//    }

//    TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
//}
//protected override void OnResize(EventArgs e)
//{
//    base.OnResize(e);
//    this.Invalidate();
//}
//}


public class BeutifulButton : Button
{
    public int rdus = 20;
    System.Drawing.Drawing2D.GraphicsPath GetRoundPath(RectangleF Rect, int radius)
    {
        float r2 = radius / 2f;
        System.Drawing.Drawing2D.GraphicsPath GraphPath = new System.Drawing.Drawing2D.GraphicsPath();
        GraphPath.AddArc(Rect.X, Rect.Y, radius, radius, 180, 90);
        GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y);
        GraphPath.AddArc(Rect.X + Rect.Width - radius, Rect.Y, radius, radius, 270, 90);
        GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2);
        GraphPath.AddArc(Rect.X + Rect.Width - radius,
                Rect.Y + Rect.Height - radius, radius, radius, 0, 90);
        GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height);
        GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - radius, radius, radius, 90, 90);
        GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2);
        GraphPath.CloseFigure();
        return GraphPath;
    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        RectangleF Rect = new RectangleF(0, 0, this.Width, this.Height);
        using (System.Drawing.Drawing2D.GraphicsPath GraphPath = GetRoundPath(Rect, rdus))
        {
            this.Region = new Region(GraphPath);
            using (Pen pen = new Pen(Color.CadetBlue, 1.75f))
            {
                pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
                e.Graphics.DrawPath(pen, GraphPath);
            }
        }
        using (LinearGradientBrush brush = new LinearGradientBrush(ClientRectangle, Color.FromArgb(255, Color.Black), Color.FromArgb(255, Color.Gray), 90f))
        {
            g.FillRectangle(brush, ClientRectangle);
        }

        TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
    }
    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        this.Invalidate();
    }
}

