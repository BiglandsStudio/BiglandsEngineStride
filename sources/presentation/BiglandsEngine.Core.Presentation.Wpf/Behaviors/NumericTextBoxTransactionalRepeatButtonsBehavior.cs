// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://BiglandsEngine3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Windows;
using Microsoft.Xaml.Behaviors;
using BiglandsEngine.Core.Transactions;
using BiglandsEngine.Core.Presentation.Controls;
using BiglandsEngine.Core.Presentation.Services;

namespace BiglandsEngine.Core.Presentation.Behaviors
{
    /// <summary>
    /// This behavior allows more convenient editing of the value of a char using a TextBox.
    /// </summary>
    public class NumericTextBoxTransactionalRepeatButtonsBehavior : Behavior<NumericTextBox>
    {
        private ITransaction transaction;

        public static DependencyProperty UndoRedoServiceProperty = DependencyProperty.Register(nameof(UndoRedoService), typeof(IUndoRedoService), typeof(NumericTextBoxTransactionalRepeatButtonsBehavior));

        public IUndoRedoService UndoRedoService { get { return (IUndoRedoService)GetValue(UndoRedoServiceProperty); } set { SetValue(UndoRedoServiceProperty, value); } }

        protected override void OnAttached()
        {
            AssociatedObject.RepeatButtonPressed += RepeatButtonPressed;
            AssociatedObject.RepeatButtonReleased += RepeatButtonReleased;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.RepeatButtonPressed -= RepeatButtonPressed;
            AssociatedObject.RepeatButtonReleased -= RepeatButtonReleased;
        }

        private void RepeatButtonPressed(object sender, RepeatButtonPressedRoutedEventArgs e)
        {
            transaction = UndoRedoService?.CreateTransaction();
        }

        private void RepeatButtonReleased(object sender, RepeatButtonPressedRoutedEventArgs e)
        {
            transaction?.Continue();
            transaction?.Complete();
            transaction = null;
        }
    }
}
