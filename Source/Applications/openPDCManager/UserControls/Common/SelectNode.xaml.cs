using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace openPDCManager.UserControls.Common
{
    public partial class SelectNode : UserControl
    {
        #region [ Members ]

        public delegate void OnNodesChanged(object sender, RoutedEventArgs e);
        public event OnNodesChanged NodeCollectionChanged;
        bool m_raiseNodesCollectionChanged = false;

        #endregion

        #region [ Constructor ]

        public SelectNode()
        {
            InitializeComponent();
        }

        #endregion

        #region [ Methods ]

        public void RaiseNotification()
        {
            m_raiseNodesCollectionChanged = true;
            if (NodeCollectionChanged != null && m_raiseNodesCollectionChanged)
                NodeCollectionChanged(this, null);
        }

        #endregion
    }
}
