namespace Console
{
    public static class Providers
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
        /// Возвращает объект Zoond.Eloquent для работы с командами.
        /// </summary>
        public static Nasty.Vendor.Zoond.Eloquent.Handler Eloquent = new Nasty.Vendor.Zoond.Eloquent.Handler();

        /// <summary>
        /// Возвращает объект Zoond.Monolit для работы с выводом.
        /// </summary>
        public static Nasty.Vendor.Zoond.Monolit.Handler Monolit = new Nasty.Vendor.Zoond.Monolit.Handler();

        /// <summary>
        /// Возвращает объект Zoond.Shelf для работы с датой и временем.
        /// </summary>
        public static Nasty.Vendor.Zoond.Shelf.Handler Shelf = new Nasty.Vendor.Zoond.Shelf.Handler();
        //END CUSTOM PROVIDERS

        /// <summary>
        /// Возвращает объект Network.Accelerator для доступа к информационным инструментам акселерации.
        /// </summary>
        public static Vendor.EP.Network.Accelerator Accelerator = new Vendor.EP.Network.Accelerator();

        /// <summary>
        /// Возвращает объект Network.Stabilisher для доступа к информационным инструментам стабилизации.
        /// </summary>
        public static Vendor.EP.Network.Stabilisher Status = new Vendor.EP.Network.Stabilisher();

        /// <summary>
        /// Возвращает объект App.Handler для взаимодействия с приложением.
        /// </summary>
        public static Vendor.EP.App.Handler App = new Vendor.EP.App.Handler();

        public static Vendor.EP.Shifter.Listener Network = new Vendor.EP.Shifter.Listener();
    }
}
