# Selling Laptops App
1. Here I used four controllers namely Home, Laptop and Register and Login controllers.

      1.1 In home Controller it is mainly used to display the available laptops and show its details.
      
      1.2 In Laptop controller it is mainly used to perform CRUD operations By the admin to Add, Remove or Modify the laptops.
      
      1.3 In register controller it is used to allow users to register and view the available Laptops.
      
      1.4 In login the user if is already registered can login to it.
      
2. It has four Models which is used to define the structure of data.

      2.1 In Laptop model it defines the data types like name, Image URl , etc.
      
      2.2 In Register model it defines the data types like name, Password, Email, etc.
      
      2.3 In Login model it defines the data types like name, password.
      
      2.4 In Details model it defines the data types like name, Image URl , etc.
      
3. In Data Layer it has AppContext And migrations.

      3.1 In Appcontext it defines all the model that are to be stored in database.
      
      3.2 In migration it tell about all the Migrations.
      
4. In startup.cs file it defines about the routing and services.

5. In appsetting.json file it defines the connection string.
