import React, { useState, useEffect } from "react";
import { useNavigate, useParams } from "react-router-dom";
import adminRoutes from "@/routing/adminRoutes";
import { findPathByLabel } from "@/utils/routingUtils";
import { tokens } from "@/layouts/Admin/AdminTheme";
import {
  useTheme,
  Box,
  Button,
  TextField,
  InputLabel,
  Chip,
  Paper,
  Typography,
} from "@mui/material";
import { Formik } from "formik";
import * as yup from "yup";
import axiosInstance from "@/utils/axiosInstance";
import Autocomplete from "@mui/material/Autocomplete";
import { useSnackbar } from "notistack";
import {
  ARTIST_GETDETAILS_URL,
  MUSICAL_PROJECTS_GETALL_URL,
  ARTIST_UPDATE_URL,
} from "@/constants/Urls";
import { ArtistUpdateSchema } from "@/validations/FormSchemas";
import LoadingIndicator from "@/components/Global/UI/LoadingIndicator";
import Header from "@/components/Admin/Header/Header";
import styles from "./ArtistUpdateForm.module.scss";

const initialValues = {
  artistName: "",
  projectIdsToAdd: [],
  projectIdsToRemove: [],
};

function ArtistUpdateForm() {
  const navigate = useNavigate();
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const { enqueueSnackbar } = useSnackbar();
  const [isDataLoaded, setIsDataLoaded] = useState(false);
  const { artistId } = useParams();
  const [allProjects, setAllProjects] = useState([]);
  const [currentProjects, setCurrentProjects] = useState([]);
  const [artistInitialValues, setArtistInitialValues] = useState(initialValues);
  const [serverErrors, setServerErrors] = useState({});

  useEffect(() => {
    axiosInstance
      .get(ARTIST_GETDETAILS_URL(artistId))
      .then((response) => {
        setArtistInitialValues({
          artistName: response.data.artistName,
          projectIdsToAdd: [],
          projectIdsToRemove: [],
        });
        setCurrentProjects(response.data.associatedProjects);
        setIsDataLoaded(true);
      })
      .catch((error) => {
        enqueueSnackbar("Error fetching artist details", { variant: "error" });
      });

      axiosInstance
      .get(MUSICAL_PROJECTS_GETALL_URL)
      .then((response) => {
        setAllProjects(response.data);
      })
      .catch((error) => {
        enqueueSnackbar("Error fetching projects", { variant: "error" });
      });
  }, [artistId, enqueueSnackbar]);

  const handleRemoveProject = (projectId, setFieldValue, values) => {
    setCurrentProjects((prev) => prev.filter((p) => p.id !== projectId));
    setFieldValue("projectIdsToRemove", [
      ...values.projectIdsToRemove,
      projectId,
    ]);
  };

  const handleFormSubmit = (values) => {
    setServerErrors({});
    // Check if currentProjects is empty
    if (currentProjects.length === 0) {
      if (values.projectIdsToAdd.length === 0) {
        enqueueSnackbar("There must be at least one associated project", {
          variant: "error",
        });
        return;
      }
    }

    const transformedData = {
      artistName: values.artistName,
      projectIdsToAdd: values.projectIdsToAdd.map((project) => project.id),
      projectIdsToRemove: values.projectIdsToRemove,
    };

    axiosInstance
      .put(ARTIST_UPDATE_URL(artistId), transformedData)
      .then((response) => {
        enqueueSnackbar("Successfully updated artist", { variant: "success" });
        navigate(findPathByLabel(adminRoutes, "Artists"));
      })
      .catch((error) => {
        if (error.response && error.response.status === 500) {
          navigate("/error500");
        } else if (
          error.response &&
          error.response.data &&
          error.response.data.errors
        ) {
          const errorsFromServer = error.response.data.errors;
          setServerErrors(errorsFromServer);
          enqueueSnackbar("Please correct the highlighted errors.", {
            variant: "error",
          });
        } else {
          enqueueSnackbar("Error updating artist", { variant: "error" });
        }
      });
  };

  if (!isDataLoaded) {
    return <LoadingIndicator />;
  }

  return (
    <Box m="20px">
      <Header title="Artists" subtitle="Update Record" />

      <Formik
        key={artistId}
        initialValues={artistInitialValues}
        validationSchema={ArtistUpdateSchema}
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
                <Box bgcolor="error.main" color="white" p={2} borderRadius={2}>
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
            <form onSubmit={handleSubmit}>
              <TextField
                fullWidth
                variant="filled"
                type="text"
                name="artistName"
                label="Artist Name"
                value={values.artistName}
                onChange={handleChange}
                onBlur={handleBlur}
                error={!!touched.artistName && !!errors.artistName}
                helperText={touched.artistName && errors.artistName}
                // Changes for increasing font size of label and helperText
                InputLabelProps={{
                  style: { fontSize: "1rem" },
                  focused: false,
                }} // Increase font size of label
                FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
              />

              <Box mt={2}>
                <InputLabel>Current Projects</InputLabel>
                <Box display="flex" flexWrap="wrap" gap="0.5rem">
                  {currentProjects.map((project) => (
                    <Chip
                      key={project.id}
                      label={project.name}
                      onDelete={() =>
                        handleRemoveProject(project.id, setFieldValue, values)
                      }
                      sx={{
                        fontSize: "0.8rem", // Increase font size
                        padding: "0.5rem", // Increase padding for balance
                        height: "auto", // Allow for dynamic height based on content
                        "& .MuiChip-label": {
                          // Targeting the label inside the chip
                          paddingRight: "1rem", // Extra padding to ensure delete icon doesn't crowd text
                        },
                      }}
                    />
                  ))}
                </Box>
              </Box>

              <Box mt={2}>
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
                  id="projectIdsToAdd"
                  options={allProjects}
                  getOptionLabel={(option) => option.name}
                  value={values.projectIdsToAdd}
                  onChange={(_, newValue) => {
                    const newProjects = newValue.filter(
                      (proj) => !currentProjects.some((cp) => cp.id === proj.id)
                    );
                    // setCurrentProjects(prev => [...prev, ...newProjects]);
                    setFieldValue("projectIdsToAdd", newProjects);
                  }}
                  renderInput={(params) => (
                    <TextField
                      {...params}
                      variant="filled"
                      label="Add Projects"
                      placeholder="Search for a project"
                    />
                  )}
                />
              </Box>

              <Box mt={2} display="flex" flexDirection="column" gap="1rem">
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
          </Box>
        )}
      </Formik>
    </Box>
  );
}

export default ArtistUpdateForm;
