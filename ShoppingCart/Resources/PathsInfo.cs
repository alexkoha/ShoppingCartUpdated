namespace ShoppingCart.Resources
{
    /*
     * Using Statically assigning values is rarely a good idea, since changing them requires a compilation.
     * When working on bigger scale projects, compilation is not as simple as Ctrl+Shift+B, and requires a lot of overhead.
     * It is therefore a good idea to ensure that the system is as flexible as possible.
     * 
     * You could create a constructor with these values as a parameter for the class which consumes these paths.
     * This would effectively delegate the supplying of these paths to class which instantiates the class which consumes the paths.
     
     * This would make your class very flexible, since it does not decide by itself the origin of the data it uses.
     * This would also enable you to easily test the classes, by providing varying paths which contain different input values according to test results.
     
     */
    public class PathsInfo
    {
        public static string XmlPath = "..\\..\\..\\xml\\";
        public static string ImagesPath = "Images/";
    }
}
