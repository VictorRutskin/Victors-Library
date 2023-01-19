using System.Windows.Controls;

namespace Victors_Library
{
    public partial class SettingDefaultsAtStart  //basically sets all defaults at run start + multiple functions 
    {

        public void DefaultSettingsMain(TextBlock textblock, Image image, Button button1, bool screeneffect)
        {
            textblock.IsEnabled = true;
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            Gif_Class gif_Class = new Gif_Class();
            Positioning_Class positioning_Class = new Positioning_Class();

            positioning_Class.SetUpAllSizes(image);
            positioning_Class.SetUpAllMiddleImage(image);
            positioning_Class.SetUpAllMiddleTextblock(textblock);


            if (screeneffect == true)
            {
                screenTextEffect_Class.ScreenSayAtRun(textblock, image, true);

            }
            else
            {
                screenTextEffect_Class.ScreenSayAtRun(textblock, image, false);

            }

            gif_Class.SettingUpAGif(1, image);
            textblock.IsEnabled = false;

        }


        public async void DefaultSettingsAddBook(TextBlock textblock, Image image,Button button)
        {
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            Gif_Class gif_Class = new Gif_Class();
            Positioning_Class positioning_Class = new Positioning_Class();

            positioning_Class.SetUpAllSizes(image);
            positioning_Class.SetUpAllMiddleTextblock(textblock);

            await screenTextEffect_Class.ScreenSay("", textblock, button, button, button);

            gif_Class.SettingUpAGif(13, image);

        }

        public async void DefaultSettingsAddBook(TextBlock textblock, Image image)
        {
            ScreenTextEffect_Class screenTextEffect_Class = new ScreenTextEffect_Class();

            Gif_Class gif_Class = new Gif_Class();
            Positioning_Class positioning_Class = new Positioning_Class();

            positioning_Class.SetUpAllSizes(image);
            positioning_Class.SetUpAllMiddleTextblock(textblock);

            await screenTextEffect_Class.ScreenSay("", textblock);

            gif_Class.SettingUpAGif(13, image);

        }

    }
}
