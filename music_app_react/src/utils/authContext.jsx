// import React, { createContext, useContext, useEffect, useState } from 'react';
// import jwtDecode from 'jwt-decode';

// const AuthContext = createContext();

// export const AuthProvider = ({ children }) => {
//   const [user, setUser] = useState(null);

//   const updateUser = (decodedToken) => {
//     setUser({
//       id: decodedToken.sub, // Subject
//       email: decodedToken.email,
//       username: decodedToken.unique_name, // Username
//       firstname: decodedToken.Firstname,
//       lastname: decodedToken.Lastname,
//       roles: decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'] // Roles, if available
//     });
//   };

//   useEffect(() => {
//     const updateAuth = () => {
//       const token = localStorage.getItem('accessToken');
//       if (token) {
//         const decodedToken = jwtDecode(token);
//         updateUser(decodedToken);
//       } else {
//         setUser(null);
//       }
//     };

//     updateAuth();

//     // Listen for changes to local storage
//     window.addEventListener('storage', updateAuth);

//     return () => {
//       window.removeEventListener('storage', updateAuth);
//     };
//   }, []);

//   const values = {
//     user,
//   };

//   return (
//     <AuthContext.Provider value={values}>
//       {children}
//     </AuthContext.Provider>
//   );
// };

// export const useAuth = () => {
//   const context = useContext(AuthContext);
//   if (!context) {
//     throw new Error('useAuth must be used within an AuthProvider');
//   }
//   return context;
// };
