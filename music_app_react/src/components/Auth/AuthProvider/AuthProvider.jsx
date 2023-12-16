import React, { createContext, useEffect, useState } from 'react';
import jwtDecode from 'jwt-decode';

export const AuthContext = createContext();

const AuthProvider = ({ children }) => {
  const [user, setUser] = useState(null);

  const updateUser = (decodedToken) => {
    setUser({
      id: decodedToken.sub,
      email: decodedToken.email,
      username: decodedToken.unique_name,
      firstname: decodedToken.Firstname,
      lastname: decodedToken.Lastname,
      roles: decodedToken['http://schemas.microsoft.com/ws/2008/06/identity/claims/role']
    });
  };

  useEffect(() => {
    const updateAuth = () => {
      const token = localStorage.getItem('accessToken');
      if (token) {
        const decodedToken = jwtDecode(token);
        updateUser(decodedToken);
      } else {
        setUser(null);
      }
    };

    updateAuth();

    window.addEventListener('storage', updateAuth);

    return () => {
      window.removeEventListener('storage', updateAuth);
    };
  }, []);

  const values = {
    user,
    updateUser,
  };

  return (
    <AuthContext.Provider value={values}>
      {children}
    </AuthContext.Provider>
  );
};

export default AuthProvider;
