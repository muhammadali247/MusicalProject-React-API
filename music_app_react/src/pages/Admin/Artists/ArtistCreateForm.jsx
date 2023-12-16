import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import adminRoutes from "@/routing/adminRoutes";
import { findPathByLabel } from "@/utils/routingUtils";
import { tokens } from "@/layouts/Admin/AdminTheme";
import {
  useTheme,
  Box,
  Button,
  TextField,
  Paper,
  Typography,
} from "@mui/material";
import { Formik } from "formik";
import * as yup from "yup";
import useMediaQuery from "@mui/material/useMediaQuery";
import Header from "@/components/Admin/Header/Header";
import axiosInstance from "@/utils/axiosInstance";
import styles from "./ArtistCreateForm.module.scss";
import { useSnackbar } from "notistack";
import {
  ARTIST_CREATE_URL,
  MUSICAL_PROJECTS_GETALL_URL,
} from "@/constants/Urls";
import Autocomplete from "@mui/material/Autocomplete";
import Chip from "@mui/material/Chip";
import { ArtistCreateSchema } from "@/validations/FormSchemas";

const initialValues = {
  artistName: "",
  projectIds: [],
};

function ArtistCreateForm() {
  const { enqueueSnackbar } = useSnackbar();
  const navigate = useNavigate();
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const [projects, setProjects] = useState([]);
  const [serverErrors, setServerErrors] = useState({});
  // const isNonMobile = useMediaQuery("(min-width:600px)");

  useEffect(() => {
    // Fetch the list of projects
    axiosInstance
      .get(MUSICAL_PROJECTS_GETALL_URL)
      .then((response) => {
        setProjects(response.data);
      })
      .catch((error) => {
        console.error("Error fetching projects:", error);
      });
  }, []);

  const handleFormSubmit = (values) => {
    const transformedData = {
      ...values,
      projectIds: values.projectIds.map((project) => project.id),
    };
    console.log(transformedData);

    axiosInstance
      .post(ARTIST_CREATE_URL, transformedData)
      .then((response) => {
        console.log("Success:", response.data);
        enqueueSnackbar("Artist added successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
        navigate(findPathByLabel(adminRoutes, "Artists"));
      })
      .catch((error) => {
        if (error.response) {
          if (error.response.status === 500) {
            navigate("/error500");
          } else if (error.response.data && error.response.data.errors) {
            const errorsFromServer = error.response.data.errors;
            setServerErrors(errorsFromServer);
            enqueueSnackbar("Please correct the highlighted errors.", {
              variant: "error",
            });
          }
        } else {
          enqueueSnackbar("Error adding artist", { variant: "error" });
        }
      });
  };

  return (
    <Box m="20px">
      <Header title="Artists" subtitle="Create New Record" />
      <Formik
        initialValues={initialValues}
        validationSchema={ArtistCreateSchema}
        onSubmit={handleFormSubmit}
      >
        {({
          values,
          errors,
          touched,
          handleBlur,
          handleChange,
          handleSubmit,
          setFieldValue,
          setFieldTouched,
        }) => (
          <form onSubmit={handleSubmit}>
            <Box
              display="flex"
              flexDirection="column"
              gap="1rem"
              width="70%"
              p="2rem"
              borderRadius="12px"
              border={`1px solid ${theme.palette.divider}`}
              bgcolor={colors.primary[400]}
              boxShadow={3}
            >
              <Box>
                {Object.keys(serverErrors).length > 0 && (
                  <Box
                    bgcolor="error.main"
                    color="white"
                    p={2}
                    borderRadius={2}
                  >
                    <Typography variant="h5">Errors:</Typography>
                    <ul>
                      {Object.entries(serverErrors).map(([field, errors]) => (
                        <li key={field}>
                          {errors.map((error, index) => (
                            <div key={index} className={styles.serverError}>
                              {error}
                            </div>
                          ))}
                        </li>
                      ))}
                    </ul>
                  </Box>
                )}
              </Box>
              <TextField
                fullWidth
                variant="filled"
                type="text"
                label="Artist Name"
                onBlur={handleBlur}
                onChange={handleChange}
                value={values.artistName}
                name="artistName"
                error={!!touched.artistName && !!errors.artistName}
                helperText={touched.artistName && errors.artistName}
                // Changes for increasing font size of label and helperText
                InputLabelProps={{
                  style: { fontSize: "1rem" },
                  focused: false,
                }} // Increase font size of label
                FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
              />

              {/* Projects Selection */}
              <Autocomplete
                PaperComponent={({ children, ...other }) => (
                  <Paper
                    {...other}
                    sx={{ backgroundColor: colors.blueAccent[700] }}
                  >
                    {children}
                  </Paper>
                )}
                multiple
                id="projectIds"
                options={projects}
                getOptionLabel={(option) => option.name}
                value={values.projectIds}
                onChange={(_, newValue) => {
                  setFieldValue("projectIds", newValue);
                  setFieldTouched("projectIds", true); // Set the touch status
                }}
                onBlur={() => setFieldTouched("projectIds", true)} // Ensure that field is marked touched on blur.
                renderInput={(params) => (
                  <TextField
                    {...params}
                    variant="filled"
                    label="Select Projects"
                    error={!!touched.projectIds && !!errors.projectIds}
                    helperText={touched.projectIds && errors.projectIds}
                    InputLabelProps={{
                      style: { fontSize: "1rem" },
                      focused: false,
                    }}
                    FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                  />
                )}
                renderTags={(selectedProjects, getTagProps) =>
                  selectedProjects.map((project, index) => (
                    <Chip
                      key={project.id} // using the unique project ID as the key
                      variant="outlined"
                      label={project.name} // displaying the project name on the chip
                      {...getTagProps({ index })}
                    />
                  ))
                }
              />
              {/* Submit Button */}
              <Button
                type="submit"
                variant="contained"
                style={{
                  backgroundColor: colors.blueAccent[400],
                  fontSize: "0.8rem",
                  fontWeight: "bold",
                }}
              >
                Submit
              </Button>
              {/* Cancel Button */}
              <Button
                variant="contained"
                style={{
                  backgroundColor: colors.grey[500],
                  fontSize: "0.8rem",
                  fontWeight: "bold",
                }}
                onClick={() => navigate(-1)} // navigating back to the previous page
              >
                Cancel
              </Button>
            </Box>
          </form>
        )}
      </Formik>
    </Box>
  );
}

export default ArtistCreateForm;
