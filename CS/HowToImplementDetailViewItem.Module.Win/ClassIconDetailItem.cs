using System;
using System.Drawing;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Utils;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.ExpressApp.Model;
using System.Windows.Forms;

namespace HowToImplementDetailViewItem.Module.Win {

    public interface IModelClassIcon : IModelViewItem { }

	[ViewItemAttribute(typeof(IModelClassIcon))]
	public class ClassIconDetailItem : ViewItem {
        private IModelClassIcon Info;
        public ClassIconDetailItem(IModelClassIcon info, Type classType)
			: base(classType, info.Id) {
            Info = info;
		}
		protected override object CreateControlCore() {
            PictureBox imageControl = new PictureBox();
            string imageName = ((IModelDetailView)Info.Parent.Parent).ImageName;
            ImageInfo imageInfo = ImageLoader.Instance.GetLargeImageInfo(imageName);
            if (imageInfo.IsEmpty) {
                imageControl.Visible = false;
            }
            else {
                Image image = imageInfo.Image;
                imageControl.Image = image;
                imageControl.Width = image.Width;
                imageControl.Height = image.Height;
            }
            return imageControl;
		}
	}
}