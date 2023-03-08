using System;
using System.ComponentModel;
using System.Windows.Threading;
using System.Runtime.CompilerServices;
using System.Threading;

namespace Youtube_DL_App.ViewModel
{
    /// <summary>
    /// View Model base implementing INotifyPropertyChanged for UI updating.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// GUI thread handle.
        /// </summary>
        private readonly Dispatcher dispatcher;

        /// <summary>
        /// Has this object been disposed?
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initialises a new instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        public ViewModelBase()
        {
            this.dispatcher = Dispatcher.CurrentDispatcher;
        }

        /// <summary>
        /// Finalises an instance of the <see cref="ViewModelBase"/> class.
        /// </summary>
        ~ViewModelBase()
        {
            // The object went out of scope and finalized is called.
            // Let's call dispose in to release unmanaged resources,
            // the managed resources will be released when GC runs
            // the next time.
            this.Dispose(false);
        }

        /// <summary>
        /// Event raised when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Deterministically performs tasks associated with freeing, releasing, or resetting all managed and unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            // If this function is being called, the user wants to release
            // the resources. Let's call dispose which will do this for us.
            this.Dispose(true);

            // Now since we have done the cleanup already, there is nothing
            // left for the finalizer to do. So let's tell GC not to run it.
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Performs tasks associated with freeing, releasing, or resetting all managed and/or unmanaged resources.
        /// </summary>
        /// <param name="disposing">Did user request disposing?</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.disposed)
            {
                return;
            }

            if (disposing == true)
            {
                // Someone wanted the deterministic release of all resources.
                // Let us release all managed resources.
                this.ReleaseManagedResources();
            }

            // This object has gone out of scope, release
            // unmanaged resources not dealt with by the GC.
            this.ReleaseUnmanagedResources();

            this.disposed = true;
        }

        /// <summary>
        /// Invoke action on Dispatcher thread.
        /// </summary>
        /// <param name="action">Action to invoke.</param>
        protected virtual void InvokeOnDispatcherAction(Action action)
        {
            if (action != null)
            {
                if (this.dispatcher.Thread == Thread.CurrentThread)
                {
                    action();
                }
                else
                {
                    this.dispatcher.Invoke(() =>
                    {
                        action();
                    }, DispatcherPriority.Send);
                }
            }
        }

        /// <summary>
        /// Release managed resources.
        /// </summary>
        protected virtual void ReleaseManagedResources()
        {
        }

        /// <summary>
        /// Release unmanaged resources.
        /// </summary>
        protected virtual void ReleaseUnmanagedResources()
        {
        }

        /// <summary>
        /// Raise the PropertyChanged event.
        /// </summary>
        /// <param name="propertyName">Property name.</param>
        /// <remarks>The calling member's name will be used as the parameter unless otherwise specified.</remarks>
        protected void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            this.InvokeOnDispatcherAction(() =>
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            });
        }

        /// <summary>
        /// Update property field.
        /// </summary>
        /// <typeparam name="T">Field data type.</typeparam>
        /// <param name="field">Field name.</param>
        /// <param name="newValue">New value.</param>
        /// <param name="propertyName">Field property name.</param>
        /// <returns><see langword="true"/> if the new value was different and the property was updated; otherwise, <see langword="false"/>.</returns>
        protected bool Set<T>(ref T? field, T? newValue = default, [CallerMemberName] string? propertyName = null)
        {
            bool changed = false;

            if (object.Equals(field, newValue) == false)
            {
                changed = true;
                field = newValue;

                this.RaisePropertyChanged(propertyName);
            }

            return changed;
        }
    }
}
