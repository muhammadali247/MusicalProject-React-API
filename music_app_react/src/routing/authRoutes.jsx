import AuthLayout from "@/layouts/Auth/AuthLayout";
import {
  SignUp,
  SignIn,
  VerifyAccount,
  ForgotPassword,
  ResetPasswordMessage,
  ResetPassword,
} from "@/pages/Auth";
import { Error404, Error500 } from "@/pages/Admin";

const authRoutes = [
  {
    path: "/auth",
    element: <AuthLayout />,
    errorElement: <Error404 />,
    children: [
      { path: "signUp", element: <SignUp />, label: "SignUp" },
      { path: "signIn", element: <SignIn />, label: "SignIn" },
      {
        path: "verifyAccount/:userId",
        element: <VerifyAccount />,
        label: "VerifyAccount",
      },
      {
        path: "forgotPassword",
        element: <ForgotPassword />,
        label: "ForgotPassword",
      },
      {
        path: "resetPasswordMessage",
        element: <ResetPasswordMessage />,
        label: "ResetPasswordMessage",
      },
      {
        path: "resetPassword",
        element: <ResetPassword />,
        label: "ResetPassword",
      },
    ],
  },
  { path: "error500", element: <Error500 /> },
];

export default authRoutes;
