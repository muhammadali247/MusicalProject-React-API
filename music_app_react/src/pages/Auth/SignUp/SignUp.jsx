import React from "react";
import Card from "@mui/material/Card";
import Button from "@mui/material/Button";
import { Checkbox, TextField, useTheme, Typography } from "@mui/material";
import { Form, Formik, useField } from "formik";
import Grid from "@mui/material/Grid";
import Box from "@mui/material/Box";
import { ReactComponent as Logo } from "@/assets/icons/signup.svg";
import { SignUpSchema } from "@/validations/FormSchemas";
import axios from "axios";
import { ACCOUNT_REGISTER_URL } from "@/constants/Urls";
import { useNavigate } from "react-router-dom";
import { useSnackbar } from "notistack";
import { findPathByLabel } from "@/utils/routingUtils";
import authRoutes from "@/routing/authRoutes";

const AppTextField = (props) => {
  const [field, meta] = useField(props);
  const errorText = meta.error && meta.touched ? meta.error : " ";
  return (
    <TextField
      {...props}
      {...field}
      helperText={errorText}
      error={meta.touched && !!meta.error}
      sx={{
        width: "100%",
        mb: 1,
      }}
    />
  );
};

const initialValues = {
  firstname: "",
  lastname: "",
  userName: "",
  phoneNumber: "",
  email: "",
  password: "",
  confirmPassword: "",
};

function SignUp() {
  const { enqueueSnackbar } = useSnackbar();
  const navigate = useNavigate();
  const theme = useTheme();
  const [serverErrors, setServerErrors] = React.useState({});

  const handleFormSubmit = async (
    values,
    { setSubmitting, setErrors, resetForm }
  ) => {
    setSubmitting(true);
    // Validate that the password and confirm password fields match
    if (values.password !== values.confirmPassword) {
      setErrors({
        confirmPassword: "Password Mismatch",
      });
      setSubmitting(false);
      return;
    }

    axios
      .post(ACCOUNT_REGISTER_URL, values)
      .then((response) => {
        console.log("Registration successful:", response.data);
        enqueueSnackbar("Account created successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
        enqueueSnackbar("The verification code has been sent to you email!", {
          variant: "info",
          autoHideDuration: 5000,
        });
        navigate(findPathByLabel(authRoutes, "VerifyAccount", { userId: response.data.userId }));
      })
      .catch((error) => {
        let errorMessage = "An error occurred while registering.";
        if (error.response) {
          if (error.response.status === 500) {
            navigate("/error500");
            return;
          } else if (error.response.data && error.response.data.errors) {
            const errorsFromServer = error.response.data.errors;
            setErrors(errorsFromServer);
            setServerErrors(errorsFromServer); // Store the server errors
            console.log(errorsFromServer);
            errorMessage = "Please correct the highlighted errors.";
          }
        }
        enqueueSnackbar(errorMessage, {
          variant: "error",
        });
      })
      .finally(() => {
        setSubmitting(false);
      });
  };

  return (
    <Box
      sx={{
        padding: "1rem",
        display: "flex",
        minHeight: "100vh",
        flex: 1,
        flexDirection: "column",
        alignItems: "center",
        justifyContent: "center",
      }}
    >
      <Card
        sx={{
          maxWidth: 1024,
          borderRadius: "2%",
          width: "100%",
          backgroundColor: "#1F2A40",
          paddingX: 8,
          paddingY: 3,
          paddingLeft: { xs: 8, md: 2 },
          overflow: "hidden",
          boxShadow:
            "0 10px 15px -3px rgba(0, 0, 0, 0.1), 0 4px 6px -2px rgba(0, 0, 0, 0.05)",
        }}
      >
        <Grid
          container
          spacing={5}
          sx={{
            alignItems: { md: "center" },
          }}
        >
          <Grid
            item
            xs={12}
            md={6}
            sx={{
              textAlign: "center",
            }}
          >
            <Logo fill={theme.palette.primary.main} />
          </Grid>
          <Grid
            item
            xs={12}
            md={6}
            sx={{
              textAlign: "center",
            }}
          >
            <Box
              sx={{
                mb: { xs: 6, xl: 3 },
                fontWeight: 700,
                fontSize: 30,
              }}
            >
              Sign Up
            </Box>
            {Object.keys(serverErrors).length > 0 && (
              <Box bgcolor="error.main" color="white" p={2} borderRadius={2}  sx={{
                mb: { xs: 6, xl: 3 }}}>
                <Typography variant="h5">Errors:</Typography>
                <ul>
                  {Object.entries(serverErrors).map(([field, errors]) => (
                    <li key={field}>
                      {errors.map((error, index) => (
                        <div key={index}>{error}</div>
                      ))}
                    </li>
                  ))}
                </ul>
              </Box>
            )}
            <Formik
              validateOnChange={true}
              initialValues={initialValues}
              validationSchema={SignUpSchema}
              onSubmit={handleFormSubmit}
            >
              {({ isSubmitting }) => (
                <Form noValidate autoComplete="off">
                  <Grid container spacing={1}>
                    <Grid item xs={12} md={6}>
                      <AppTextField
                        label="Firstname"
                        name="firstname"
                        variant="outlined"
                      />
                    </Grid>
                    <Grid item xs={12} md={6}>
                      <AppTextField
                        label="Lastname"
                        name="lastname"
                        variant="outlined"
                      />
                    </Grid>
                    <Grid item xs={12} md={6}>
                      <AppTextField
                        label="UserName"
                        name="userName"
                        variant="outlined"
                      />
                    </Grid>
                    <Grid item xs={12} md={6}>
                      <AppTextField
                        label="Phone Number"
                        name="phoneNumber"
                        variant="outlined"
                      />
                    </Grid>
                    <Grid item xs={12}>
                      <AppTextField
                        label="Email"
                        name="email"
                        variant="outlined"
                      />
                    </Grid>
                    <Grid item xs={12} md={6}>
                      <AppTextField
                        label="Password"
                        name="password"
                        type="password"
                        variant="outlined"
                        autoComplete="current-password"
                      />
                    </Grid>
                    <Grid item xs={12} md={6}>
                      <AppTextField
                        label="Retype Password"
                        name="confirmPassword"
                        type="password"
                        variant="outlined"
                      />
                    </Grid>
                  </Grid>
                  <Box
                    sx={{
                      mb: { xs: 5, xl: 2 },
                      display: "flex",
                      flexWrap: "wrap",
                      alignItems: "center",
                    }}
                  >
                    <Checkbox />
                    <Box component="span" sx={{ mr: 2, fontSize: 14 }}>
                      I agree to
                    </Box>
                    <Box
                      component="span"
                      sx={{
                        cursor: "pointer",
                        color: "primary.main",
                        fontWeight: 700,
                        fontSize: 14,
                      }}
                    >
                      Terms & Conditions
                    </Box>
                  </Box>
                  <Button
                    variant="contained"
                    color="primary"
                    disabled={isSubmitting}
                    sx={{
                      width: "100%",
                      height: 44,
                    }}
                    type="submit"
                  >
                    Sign Up
                  </Button>
                </Form>
              )}
            </Formik>

            <Box
              sx={{
                textAlign: "center",
                color: "grey.700",
                fontSize: 14,
                fontWeight: 700,
                mt: { xs: 3, xl: 2 },
              }}
            >
              <Box component="span" sx={{ mr: 1 }}>
                Already have an account?
              </Box>
              <Box
                component="span"
                sx={{
                  color: "primary.main",
                  fontWeight: 500,
                  cursor: "pointer",
                }}
                onClick={() => navigate(findPathByLabel(authRoutes, "SignIn"))}
              >
                Sign In Here
              </Box>
            </Box>
          </Grid>
        </Grid>
      </Card>
    </Box>
  );
}

export default SignUp;
