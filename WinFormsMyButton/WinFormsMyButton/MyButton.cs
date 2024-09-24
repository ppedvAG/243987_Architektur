using System.Drawing.Drawing2D;

namespace WinFormsMyButton
{
    internal class MyButton : Button
    {
        int paintCount = 0;

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, this.Width, this.Height);
            this.Region = new Region(path);

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.FillEllipse(new SolidBrush(Color.Red), 0, 0, this.Width, this.Height);

            Parent.Text = "Paint count: " + paintCount++;
        }
    }
}
