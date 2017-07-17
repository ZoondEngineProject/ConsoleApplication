namespace LaHelper
{
    class Providers
    {

        /*
         * CUSTOM PROVIDERS
         * ----------------
         * @package Zoond
         * @author Mango
         * @since 2017
         * @version 1.3
         */
        /// <summary>
        /// Возвращает объект Eloquent для работы с командами.
        /// </summary>
        public static Nasty.Vendor.Zoond.Eloquent.Handler Eloquent = new Nasty.Vendor.Zoond.Eloquent.Handler();

        /// <summary>
        /// Возвращает объект Monolit для работы с выводом.
        /// </summary>
        public static Nasty.Vendor.Zoond.Monolit.Handler Monolit = new Nasty.Vendor.Zoond.Monolit.Handler();

        /// <summary>
        /// Возвращает объект Shelf для работы с датой и временем.
        /// </summary>
        public static Nasty.Vendor.Zoond.Shelf.Handler Shelf = new Nasty.Vendor.Zoond.Shelf.Handler();
        //END CUSTOM PROVIDERS

        public static Vendor.EP.Network.Accelerator Accelerator = new Vendor.EP.Network.Accelerator();

        public static Vendor.EP.Network.Stabilisher Status = new Vendor.EP.Network.Stabilisher();
    }
}
