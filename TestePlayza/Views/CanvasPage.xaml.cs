using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using System.Collections.Generic;
using System;

namespace Playza.Views;

public partial class CanvasPage : ContentPage
{
    private List<(PointF, Color)> _points = new();
    private Color _currentColor = Colors.Black;
    private bool _isErasing = false;
    private bool _isPaused = false;
    private PointF? _lastPoint = null;

    public IDrawable Drawable { get; private set; }

    public CanvasPage()
    {
        InitializeComponent();
        Drawable = new DrawingSurface(_points);
        BindingContext = this;
    }

    private void OnStartInteraction(object sender, TouchEventArgs e)
    {
        if (_isPaused) return;

        _lastPoint = null; // <- quebra a linha anterior
        AddPoint(e.Touches[0]);
    }

    private void OnDragInteraction(object sender, TouchEventArgs e)
    {
        if (_isPaused) return;
        AddPoint(e.Touches[0]);
    }

    private void OnEndInteraction(object sender, TouchEventArgs e)
    {
        if (_isPaused) return;
        AddPoint(e.Touches[0]);
        _lastPoint = null;
    }

    private void AddPoint(PointF point)
    {
        var color = _isErasing ? Colors.White : _currentColor;

        if (_lastPoint != null)
        {
            var distance = Distance(_lastPoint.Value, point);
            int steps = (int)(distance / 2);

            for (int i = 1; i <= steps; i++)
            {
                float t = (float)i / steps;
                float x = _lastPoint.Value.X + (point.X - _lastPoint.Value.X) * t;
                float y = _lastPoint.Value.Y + (point.Y - _lastPoint.Value.Y) * t;
                _points.Add((new PointF(x, y), color));
            }
        }
        else
        {
            _points.Add((point, color));
        }

        _lastPoint = point;
        DrawingCanvas.Invalidate();
    }



    private float Distance(PointF a, PointF b)
    {
        float dx = a.X - b.X;
        float dy = a.Y - b.Y;
        return (float)Math.Sqrt(dx * dx + dy * dy);
    }

    private void OnColorSelected(object sender, EventArgs e)
    {
        if (sender is ImageButton btn)
        {
            string image = btn.Source.ToString().ToLower();
            _isErasing = false;

            if (image.Contains("black")) _currentColor = Colors.Black;
            else if (image.Contains("red")) _currentColor = Colors.Red;
            else if (image.Contains("green")) _currentColor = Colors.Green;
            else if (image.Contains("blue")) _currentColor = Colors.Blue;
        }
    }

    private void OnEraserClicked(object sender, EventArgs e) => _isErasing = true;

    private void OnClearClicked(object sender, EventArgs e)
    {
        _points.Clear();
        DrawingCanvas.Invalidate();
    }

    private void OnPauseClicked(object sender, EventArgs e)
    {
        _isPaused = true;
        PauseMenu.IsVisible = true;
    }

    private void OnResumeClicked(object sender, EventArgs e)
    {
        _isPaused = false;
        PauseMenu.IsVisible = false;
    }

    private async void OnExitClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("JourneyPage");
    }

    class DrawingSurface : IDrawable
    {
        private readonly List<(PointF point, Color color)> _points;

        public DrawingSurface(List<(PointF, Color)> points)
        {
            _points = points;
        }

        public void Draw(ICanvas canvas, RectF dirtyRect)
        {
            for (int i = 1; i < _points.Count; i++)
            {
                var (p1, c1) = _points[i - 1];
                var (p2, c2) = _points[i];

                canvas.StrokeColor = c1;
                canvas.StrokeSize = c1 == Colors.White ? 20 : 8; // Borracha maior

                canvas.DrawLine(p1.X, p1.Y, p2.X, p2.Y);
            }
        }


        private float Distance(PointF a, PointF b)
        {
            float dx = a.X - b.X;
            float dy = a.Y - b.Y;
            return (float)Math.Sqrt(dx * dx + dy * dy);
        }
    }
}