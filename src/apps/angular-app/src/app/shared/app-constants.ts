export class AppConstants {  

   /* Api Urls */   
 private static API_BASE_URL_ORDERS = "http://localhost:5000";
 private static API_BASE_URL_PAYMENT = ""; 
   
 static GET_USER_API = "/api/users";

 /* Orders Api Urls */
  
  static GET_PRODUCTS_CATEGORIES_URL = () => `${AppConstants.API_BASE_URL_ORDERS}/product`;
}

