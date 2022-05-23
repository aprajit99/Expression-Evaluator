using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ExpressionEvaluatorUi.ViewModels.Helpers
{
    public class TextBoxHelper:DependencyObject
    {
        public static void SetCursorPosition(DependencyObject dependencyObject, int i)
        {
            dependencyObject.SetValue(CursorPositionProperty, i);
        }

        public static int GetCursorPosition(DependencyObject dependencyObject)
        {
            return (int)dependencyObject.GetValue(CursorPositionProperty);
        }

        public static readonly DependencyProperty CursorPositionProperty =DependencyProperty.Register("CursorPosition", typeof(int), typeof(TextBoxHelper)
                                                                       , new FrameworkPropertyMetadata(default(int))
                                                                       {
                                                                           BindsTwoWayByDefault = true
                                                                       }
                                                                       );

        public static readonly DependencyProperty TrackCaretIndexProperty =
                                                    DependencyProperty.RegisterAttached(
                                                        "TrackCaretIndex",
                                                        typeof(bool),
                                                        typeof(TextBoxHelper),
                                                        new UIPropertyMetadata(false, OnTrackCaretIndex));

        public static UpdateSourceTrigger PropertyChanged { get; private set; }

        public static void SetTrackCaretIndex(DependencyObject dependencyObject, bool i)
        {
            dependencyObject.SetValue(TrackCaretIndexProperty, i);
        }
        public static bool GetTrackCaretIndex(DependencyObject dependencyObject)
        {
            return (bool)dependencyObject.GetValue(TrackCaretIndexProperty);
        }
        private static void OnTrackCaretIndex(DependencyObject dependency, DependencyPropertyChangedEventArgs e)
        {
            var textbox = dependency as TextBox;

            if (textbox == null)
                return;
            bool oldValue = (bool)e.OldValue;
            bool newValue = (bool)e.NewValue;

            if (!oldValue && newValue)
            {
                textbox.SelectionChanged += OnSelectionChanged;
            }
            else if (oldValue && !newValue)
            {
                textbox.SelectionChanged -= OnSelectionChanged;
            }
        }
        private static void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var textbox = sender as TextBox;

            if (textbox != null)
                SetCursorPosition(textbox, textbox.CaretIndex);
        }
    }
}
