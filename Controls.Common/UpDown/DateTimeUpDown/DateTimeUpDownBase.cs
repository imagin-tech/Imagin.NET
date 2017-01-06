﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace Imagin.Controls.Common
{
    public abstract class DateTimeUpDownBase<T> : UpDownBase<T>
    {
        #region Properties

        internal List<DateTimeInfo> _dateTimeInfoList = new List<DateTimeInfo>();

        internal DateTimeInfo _selectedDateTimeInfo;

        internal bool _fireSelectionChangedEvent = true;

        internal bool _processTextChanged = true;

        #region CurrentDateTimePart

        public static readonly DependencyProperty CurrentDateTimePartProperty = DependencyProperty.Register("CurrentDateTimePart", typeof(DateTimePart)
            , typeof(DateTimeUpDownBase<T>), new UIPropertyMetadata(DateTimePart.Other, OnCurrentDateTimePartChanged));
        public DateTimePart CurrentDateTimePart
        {
            get
            {
                return (DateTimePart)GetValue(CurrentDateTimePartProperty);
            }
            set
            {
                SetValue(CurrentDateTimePartProperty, value);
            }
        }

        private static void OnCurrentDateTimePartChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            DateTimeUpDownBase<T> dateTimeUpDownBase = o as DateTimeUpDownBase<T>;
            if (dateTimeUpDownBase != null)
                dateTimeUpDownBase.OnCurrentDateTimePartChanged((DateTimePart)e.OldValue, (DateTimePart)e.NewValue);
        }

        protected virtual void OnCurrentDateTimePartChanged(DateTimePart oldValue, DateTimePart newValue)
        {
            this.Select(this.GetDateTimeInfo(newValue));
        }

        #endregion //CurrentDateTimePart

        #region Step

        public static readonly DependencyProperty StepProperty = DependencyProperty.Register("Step", typeof(int)
            , typeof(DateTimeUpDownBase<T>), new UIPropertyMetadata(1, OnStepChanged));
        public int Step
        {
            get
            {
                return (int)GetValue(StepProperty);
            }
            set
            {
                SetValue(StepProperty, value);
            }
        }

        private static void OnStepChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            var dateTimeUpDownBase = o as DateTimeUpDownBase<T>;
            if (dateTimeUpDownBase != null)
                dateTimeUpDownBase.OnStepChanged((int)e.OldValue, (int)e.NewValue);
        }

        protected virtual void OnStepChanged(int oldValue, int newValue)
        {
        }

        #endregion //Step

        #endregion

        #region DateTimeUpDownBase

        internal DateTimeUpDownBase()
        {
            this.InitializeDateTimeInfoList();
            this.Loaded += this.DateTimeUpDownBase_Loaded;
        }

        #endregion

        #region Methods

        #region Handlers

        void TextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (_fireSelectionChangedEvent)
                this.PerformMouseSelection();
            else
                _fireSelectionChangedEvent = true;
        }

        void DateTimeUpDownBase_Loaded(object sender, RoutedEventArgs e)
        {
            this.InitSelection();
        }

        #endregion

        #region Overrides

        public override void OnApplyTemplate()
        {
            if (this.TextBox != null)
            {
                this.TextBox.SelectionChanged -= this.TextBox_SelectionChanged;
            }

            base.OnApplyTemplate();

            if (this.TextBox != null)
            {
                this.TextBox.SelectionChanged += this.TextBox_SelectionChanged;
            }
        }

        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            int selectionStart = (_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.StartPosition : 0;
            int selectionLength = (_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.Length : 0;

            switch (e.Key)
            {
                case Key.Enter:
                    {
                        if (!IsReadOnly)
                        {
                            _fireSelectionChangedEvent = false;
                            BindingExpression binding = BindingOperations.GetBindingExpression(TextBox, System.Windows.Controls.TextBox.TextProperty);
                            binding.UpdateSource();
                            _fireSelectionChangedEvent = true;
                        }
                        return;
                    }
                case Key.Add:
                    if (this.AllowSpin && !this.IsReadOnly)
                    {
                        this.DoIncrement();
                        e.Handled = true;
                    }
                    _fireSelectionChangedEvent = false;
                    break;
                case Key.Subtract:
                    if (this.AllowSpin && !this.IsReadOnly)
                    {
                        this.DoDecrement();
                        e.Handled = true;
                    }
                    _fireSelectionChangedEvent = false;
                    break;
                case Key.OemSemicolon:
                    if (this.IsCurrentValueValid() && (Keyboard.Modifiers == ModifierKeys.Shift))
                    {
                        this.PerformKeyboardSelection(selectionStart + selectionLength);
                        e.Handled = true;
                    }
                    _fireSelectionChangedEvent = false;
                    break;
                case Key.OemPeriod:
                case Key.OemComma:
                case Key.OemQuotes:
                case Key.OemMinus:
                case Key.Divide:
                case Key.Decimal:
                case Key.Right:
                    if (this.IsCurrentValueValid())
                    {
                        this.PerformKeyboardSelection(selectionStart + selectionLength);
                        e.Handled = true;
                    }
                    _fireSelectionChangedEvent = false;
                    break;
                case Key.Left:
                    if (this.IsCurrentValueValid())
                    {
                        this.PerformKeyboardSelection(selectionStart > 0 ? selectionStart - 1 : 0);
                        e.Handled = true;
                    }
                    _fireSelectionChangedEvent = false;
                    break;
                default:
                    {
                        _fireSelectionChangedEvent = false;
                        break;
                    }
            }

            base.OnPreviewKeyDown(e);
        }

        #endregion

        protected virtual void InitializeDateTimeInfoList()
        {
        }

        protected virtual bool IsCurrentValueValid()
        {
            return true;
        }

        protected virtual void PerformMouseSelection()
        {
            this.Select(this.GetDateTimeInfo(TextBox.SelectionStart));
        }

        protected virtual bool IsLowerThan(T value1, T value2)
        {
            return false;
        }

        protected virtual bool IsGreaterThan(T value1, T value2)
        {
            return false;
        }

        internal DateTimeInfo GetDateTimeInfo(int selectionStart)
        {
            return _dateTimeInfoList.FirstOrDefault((info) =>
                                   (info.StartPosition <= selectionStart) && (selectionStart < (info.StartPosition + info.Length)));
        }

        internal DateTimeInfo GetDateTimeInfo(DateTimePart part)
        {
            return _dateTimeInfoList.FirstOrDefault((info) => info.Type == part);
        }

        internal void Select(DateTimeInfo info)
        {
            if ((info != null) && !info.Equals(_selectedDateTimeInfo) && (this.TextBox != null) && !string.IsNullOrEmpty(this.TextBox.Text))
            {
                _fireSelectionChangedEvent = false;
                this.TextBox.Select(info.StartPosition, info.Length);
                _fireSelectionChangedEvent = true;
                _selectedDateTimeInfo = info;
#if VS2008
            this.CurrentDateTimePart = info.Type;
#else
                this.SetCurrentValue(DateTimeUpDownBase<T>.CurrentDateTimePartProperty, info.Type);
#endif
            }
        }

        internal T CoerceValueMinMax(T value)
        {
            if (this.IsLowerThan(value, this.Minimum))
                return this.Minimum;
            else if (this.IsGreaterThan(value, this.Maximum))
                return this.Maximum;
            else
                return value;
        }

        internal void ValidateDefaultMinMax(T value)
        {
            // DefaultValue is always accepted.
            if (object.Equals(value, this.DefaultValue))
                return;

            if (this.IsLowerThan(value, this.Minimum))
                throw new ArgumentOutOfRangeException("Minimum", String.Format("Value must be greater than MinValue of {0}", this.Minimum));
            else if (this.IsGreaterThan(value, this.Maximum))
                throw new ArgumentOutOfRangeException("Maximum", String.Format("Value must be less than MaxValue of {0}", this.Maximum));
        }

        internal T GetClippedMinMaxValue(T value)
        {
            if (this.IsGreaterThan(value, this.Maximum))
                return this.Maximum;
            else if (this.IsLowerThan(value, this.Minimum))
                return this.Minimum;
            return value;
        }

        private void PerformKeyboardSelection(int nextSelectionStart)
        {
            this.TextBox.Focus();

            this.CommitInput();

            int selectedDateStartPosition = (_selectedDateTimeInfo != null) ? _selectedDateTimeInfo.StartPosition : 0;
            int direction = nextSelectionStart - selectedDateStartPosition;
            if (direction > 0)
            {
                this.Select(this.GetNextDateTimeInfo(nextSelectionStart));
            }
            else
            {
                this.Select(this.GetPreviousDateTimeInfo(nextSelectionStart - 1));
            }
        }

        private DateTimeInfo GetNextDateTimeInfo(int nextSelectionStart)
        {
            DateTimeInfo nextDateTimeInfo = this.GetDateTimeInfo(nextSelectionStart);
            if (nextDateTimeInfo == null)
            {
                nextDateTimeInfo = _dateTimeInfoList.First();
            }

            DateTimeInfo initialDateTimeInfo = nextDateTimeInfo;

            while (nextDateTimeInfo.Type == DateTimePart.Other)
            {
                nextDateTimeInfo = this.GetDateTimeInfo(nextDateTimeInfo.StartPosition + nextDateTimeInfo.Length);
                if (nextDateTimeInfo == null)
                {
                    nextDateTimeInfo = _dateTimeInfoList.First();
                }
                if (object.Equals(nextDateTimeInfo, initialDateTimeInfo))
                    throw new InvalidOperationException("Couldn't find a valid DateTimeInfo.");
            }
            return nextDateTimeInfo;
        }

        private DateTimeInfo GetPreviousDateTimeInfo(int previousSelectionStart)
        {
            DateTimeInfo previousDateTimeInfo = this.GetDateTimeInfo(previousSelectionStart);
            if (previousDateTimeInfo == null)
            {
                if (_dateTimeInfoList.Count > 0)
                {
                    previousDateTimeInfo = _dateTimeInfoList.Last();
                }
            }

            DateTimeInfo initialDateTimeInfo = previousDateTimeInfo;

            while ((previousDateTimeInfo != null) && (previousDateTimeInfo.Type == DateTimePart.Other))
            {
                previousDateTimeInfo = this.GetDateTimeInfo(previousDateTimeInfo.StartPosition - 1);
                if (previousDateTimeInfo == null)
                {
                    previousDateTimeInfo = _dateTimeInfoList.Last();
                }
                if (object.Equals(previousDateTimeInfo, initialDateTimeInfo))
                    throw new InvalidOperationException("Couldn't find a valid DateTimeInfo.");
            }
            return previousDateTimeInfo;
        }

        private void InitSelection()
        {
            if (_selectedDateTimeInfo == null)
            {
                this.Select((this.CurrentDateTimePart != DateTimePart.Other) ? this.GetDateTimeInfo(this.CurrentDateTimePart) : this.GetDateTimeInfo(0));
            }
        }

        #endregion
    }
}

/*************************************************************************************

   Extended WPF Toolkit 8.0.30703

   Copyright (C) 2007-2013 Xceed Software Inc.

   This program is provided to you under the terms of the Microsoft Public
   License (Ms-PL) as published at http://wpftoolkit.codeplex.com/license 

   For more features, controls, and fast professional support,
   pick up the Plus Edition at http://xceed.com/wpf_toolkit

   Stay informed: follow @datagrid on Twitter or Like http://facebook.com/datagrids

*************************************************************************************/