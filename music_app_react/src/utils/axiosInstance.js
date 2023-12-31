import axios from "axios";
import { ACCOUNT_RENEW_TOKEN_URL } from "@/constants/Urls";
import jwtDecode from "jwt-decode";

const axiosInstance = axios.create();
axiosInstance.defaults.withCredentials = true;

let isRefreshing = false;
let refreshSubscribers = [];

axiosInstance.interceptors.request.use(
  async (config) => {
    const accessToken = localStorage.getItem("accessToken");
    const currentTime = Date.now() / 1000;

    if (
      !accessToken ||
      parseInt(localStorage.getItem("tokenExpiration")) < currentTime
    ) {
      // Token is absent or expired; attempt to renew it



      
      // If the token is expired, remove it from localStorage
      if (accessToken && parseInt(localStorage.getItem("tokenExpiration")) < currentTime) {
        localStorage.removeItem("accessToken");
        localStorage.removeItem("tokenExpiration");
      }



      if (!isRefreshing) {
        isRefreshing = true;
        try {
          // Make a request to renew the token
          const response = await axios.post(ACCOUNT_RENEW_TOKEN_URL, null, {
            headers: {
              "Content-Type": "application/json",
            },
          });
          if (response.data.accessToken) {
            // Update the accessToken in localStorage
            localStorage.setItem("accessToken", response.data.accessToken);
            // Decode the new token to get the expiration time
            const decodedToken = jwtDecode(response.data.accessToken);
            const expirationTime = decodedToken.exp;
            // Update the token expiration time in localStorage
            localStorage.setItem("tokenExpiration", expirationTime);

            // Update the request header with the new accessToken
            config.headers.Authorization = `Bearer ${response.data.accessToken}`;
          }
        } catch (error) {
          // Handle token renewal error
          console.error("Token renewal error:", error);
          // Logout mechanism here
          throw error;
        } finally {
          isRefreshing = false;
          refreshSubscribers.forEach((callback) => callback());
          refreshSubscribers = [];
        }
      }

      // If token is being refreshed, add the callback to the subscribers
      return new Promise((resolve) => {
        refreshSubscribers.push(() => {
          // Update the request header with the new accessToken
          config.headers.Authorization = `Bearer ${localStorage.getItem(
            "accessToken"
          )}`;
          resolve(config);
        });
      });
    } else {
      // Token is valid, add it to the request header
      config.headers.Authorization = `Bearer ${accessToken}`;
    }

    return config;
  },
  (error) => {
    return Promise.reject(error);
  }
);

export default axiosInstance;

// ---> Initial Version of handleRenewal
// const handleRenewal = async () => {
//   try {
//     // Send a POST request to renew the token
//     const response = await axios.post(ACCOUNT_RENEW_TOKEN_URL, null, { headers: {
//       'Content-Type': 'application/json',
//     },});

//     // Handle the response as needed (e.g., storing the new token)
//     const newToken = response.data.accessToken;
//     localStorage.setItem("auth_token", newToken);

//     // Show a success notification
//     enqueueSnackbar("Token renewed successfully!", {
//       variant: "success",
//       autoHideDuration: 5000,
//     });
//   } catch (error) {
//     // Handle errors (e.g., display an error notification)
//     console.error("Token renewal error:", error);
//     enqueueSnackbar("Error renewing token. Please try again.", {
//       variant: "error",
//     });
//   }
// };

// ---> Version 2
// axiosInstance.interceptors.request.use(
//   async (config) => {
//     const accessToken = localStorage.getItem("accessToken");
//     if (accessToken) {
//       // Check if the accessToken is expired
//       const currentTime = Date.now() / 1000;
//       const tokenExpiration = parseInt(localStorage.getItem("tokenExpiration"));
//       if (tokenExpiration && tokenExpiration < currentTime) {
//         if (!isRefreshing) {
//           isRefreshing = true;
//           try {
//             const response = await axiosInstance.post(ACCOUNT_RENEW_TOKEN_URL);
//             if (response.data.accessToken) {
//               // Update the accessToken in localStorage
//               localStorage.setItem("accessToken", response.data.accessToken);
//               // Decode the new token to get the expiration time
//               const decodedToken = jwtDecode(response.data.accessToken);
//               const expirationTime = decodedToken.exp;
//               // Update the token expiration time in localStorage
//               localStorage.setItem("tokenExpiration", expirationTime);

//               // Update the request header with the new accessToken
//               config.headers.Authorization = `Bearer ${response.data.accessToken}`;
//             }
//           } catch (error) {
//             // Handle token renewal error
//             console.error("Token renewal error:", error);
//             // logout mechanism here
//             throw error;
//           } finally {
//             isRefreshing = false;
//             refreshSubscribers.forEach((callback) => callback());
//             refreshSubscribers = [];
//           }
//         }

//         // If token is being refreshed, add the callback to the subscribers
//         return new Promise((resolve) => {
//           refreshSubscribers.push(() => {
//             // Update the request header with the new accessToken
//             config.headers.Authorization = `Bearer ${localStorage.getItem(
//               "accessToken"
//             )}`;
//             resolve(config);
//           });
//         });
//       } else {
//         // Token is valid, add it to the request header
//         config.headers.Authorization = `Bearer ${accessToken}`;
//       }
//     }
//     return config;
//   },
//   (error) => {
//     return Promise.reject(error);
//   }
// );
