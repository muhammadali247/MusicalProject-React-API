import styles from "./EventsCreateForm.module.scss";
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
  InputLabel,
  Input,
  FormHelperText,
  MenuItem,
  FormControlLabel,
  Checkbox,
} from "@mui/material";
import { Formik } from "formik";
import Header from "@/components/Admin/Header/Header";
import axiosInstance from "@/utils/axiosInstance";
import { useSnackbar } from "notistack";
import {
  EVENTS_CREATE_URL,
  MUSICAL_PROJECTS_GETALL_URL,
} from "@/constants/Urls";
import Autocomplete from "@mui/material/Autocomplete";
import Chip from "@mui/material/Chip";
import { EventCreateSchema } from "@/validations/FormSchemas";
import { DateTimePicker } from "@mui/x-date-pickers/DateTimePicker";
import { EVENT_STATUSES, TICKET_TYPES } from "@/constants/Enums";

const initialValues = {
  title: "", // Event Title
  description: "", // Event Description
  eventDate: null, // Event Date
  eventDuration: "", // Event Duration
  coverImageFile: null, // Cover Image URL
  liveStreamUrl: "", // Live Stream URL
  status: "Draft", // Event Status (Enum value)
  location: "", // Event Location
  musicalProjectIds: [], // List of Musical Project IDs
  generateTickets: false, // Generate Tickets Checkbox
  numberOfTickets: "", // Number of Tickets
  ticketPrice: "", // Ticket Price
  ticketType: "Regular", // Ticket Type (Enum value)
};

function EventsCreateForm() {
  const { enqueueSnackbar } = useSnackbar();
  const navigate = useNavigate();
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const [musicalProjects, setMusicalProjects] = useState([]);
  const [serverErrors, setServerErrors] = useState({});
  // const isNonMobile = useMediaQuery("(min-width:600px)");

  useEffect(() => {
    // Fetch the list of projects
    axiosInstance
      .get(MUSICAL_PROJECTS_GETALL_URL)
      .then((response) => {
        setMusicalProjects(response.data);
      })
      .catch((error) => {
        console.error("Error fetching projects:", error);
      });
  }, []);

  const handleFormSubmit = (values) => {
    //const transformedData = {
    //   ...values,
    //  eventDuration: values.eventDuration === "" ? null : values.eventDuration,
    //  musicalProjectIds: values.musicalProjectIds.map(
    //   (musicalProject) => musicalProject.id
    //),
    //};
    //console.log(transformedData);

    const formData = new FormData();
    // Append all form fields to the FormData object
    formData.append("title", values.title);
    formData.append("description", values.description);
    if (values.eventDate !== null) {
      formData.append("eventDate", values.eventDate.toISOString());
    }
    if (values.eventDuration !== "") {
      formData.append("eventDuration", values.eventDuration);
    }
    formData.append("coverImageFile", values.coverImageFile); // Append file
    formData.append("liveStreamUrl", values.liveStreamUrl);
    formData.append("status", values.status);
    formData.append("location", values.location);
    formData.append("generateTickets", values.generateTickets);
    if (values.numberOfTickets !== "") {
      formData.append("numberOfTickets", values.numberOfTickets);
    }
    if (values.ticketPrice !== "") {
      formData.append("ticketPrice", values.ticketPrice);
    }
    formData.append("ticketType", values.ticketType);

    // Append musical project IDs
    values.musicalProjectIds.forEach((project) => {
      formData.append("musicalProjectIds", project.id);
    });

    for (const entry of formData.entries()) {
      console.log(entry);
    }

    axiosInstance
      .post(EVENTS_CREATE_URL, formData, {
        headers: {
          "Content-Type": "multipart/form-data", // Set the appropriate content type
        },
      })
      .then((response) => {
        console.log("Success:", response.data);
        enqueueSnackbar("Event added successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
        if (values.generateTickets) {
          enqueueSnackbar("Tickets generated successfully!", {
            variant: "info",
            autoHideDuration: 5000,
          });
        }

        navigate(findPathByLabel(adminRoutes, "Events"));
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
          enqueueSnackbar("Error adding event", { variant: "error" });
        }
      });
  };

  return (
    <Box m="20px">
      <Header title="Events" subtitle="Create New Record" />
      <Formik
        initialValues={initialValues}
        validationSchema={EventCreateSchema}
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
              width="90%"
              px="2rem"
              py="1.5rem"
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

              <Box className={styles.InputRow}>
                <TextField
                  fullWidth
                  variant="filled"
                  type="text"
                  label="Title"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.title}
                  name="title"
                  error={!!touched.title && !!errors.title}
                  helperText={
                    touched.title && errors.title ? errors.title : "\u00a0"
                  }
                  // Changes for increasing font size of label and helperText
                  InputLabelProps={{
                    style: { fontSize: "1rem" },
                    focused: false,
                  }} // Increase font size of label
                  FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                />

                <TextField
                  fullWidth
                  variant="filled"
                  type="text"
                  label="Description"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.description}
                  name="description"
                  error={!!touched.description && !!errors.description}
                  helperText={
                    touched.description && errors.description
                      ? errors.description
                      : "\u00a0"
                  }
                  // Changes for increasing font size of label and helperText
                  InputLabelProps={{
                    style: { fontSize: "1rem" },
                    focused: false,
                  }} // Increase font size of label
                  FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                />

                <DateTimePicker
                  disablePast
                  label="Event Date"
                  value={values.eventDate}
                  onBlur={() => setFieldTouched("eventDate", true)}
                  onChange={(date) => setFieldValue("eventDate", date)}
                  slotProps={{
                    textField: {
                      fullWidth: true,
                      variant: "filled",
                      error:
                        Boolean(touched.eventDate) && Boolean(errors.eventDate),
                      helperText:
                        touched.eventDate && errors.eventDate
                          ? errors.eventDate
                          : "\u00a0",
                      InputLabelProps: {
                        style: { fontSize: "1rem" },
                        focused: false,
                      },
                      FormHelperTextProps: { style: { fontSize: "0.9rem" } },
                    },
                  }}
                />
              </Box>

              <Box className={styles.InputRow}>
                <TextField
                  fullWidth
                  variant="filled"
                  type="number"
                  label="Event Duration"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.eventDuration}
                  name="eventDuration"
                  error={!!touched.eventDuration && !!errors.eventDuration}
                  helperText={
                    touched.eventDuration && errors.eventDuration
                      ? errors.eventDuration
                      : "\u00a0"
                  }
                  // Changes for increasing font size of label and helperText
                  InputLabelProps={{
                    style: { fontSize: "1rem" },
                    focused: false,
                  }} // Increase font size of label
                  FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                />

                <TextField
                  fullWidth
                  variant="filled"
                  type="text"
                  label="LiveStreamUrl"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.liveStreamUrl}
                  name="liveStreamUrl"
                  error={!!touched.liveStreamUrl && !!errors.liveStreamUrl}
                  helperText={
                    touched.liveStreamUrl && errors.liveStreamUrl
                      ? errors.liveStreamUrl
                      : "\u00a0"
                  }
                  // Changes for increasing font size of label and helperText
                  InputLabelProps={{
                    style: { fontSize: "1rem" },
                    focused: false,
                  }} // Increase font size of label
                  FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                />

                <TextField
                  fullWidth
                  variant="filled"
                  select
                  label="Status"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.status}
                  name="status"
                  error={!!touched.status && !!errors.status}
                  helperText={
                    touched.status && errors.status ? errors.status : "\u00a0"
                  }
                  // Changes for increasing font size of label and helperText
                  InputLabelProps={{
                    style: { fontSize: "1rem" },
                    focused: false,
                  }} // Increase font size of label
                  FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                  SelectProps={{
                    MenuProps: {
                      PaperProps: {
                        style: {
                          backgroundColor: colors.blueAccent[700],
                        },
                      },
                    },
                  }}
                >
                  {EVENT_STATUSES.map((status) => (
                    <MenuItem key={status} value={status}>
                      {status}
                    </MenuItem>
                  ))}
                </TextField>
              </Box>

              <Box className={styles.InputRow}>
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
                  fullWidth
                  multiple
                  id="musicalProjectIds"
                  options={musicalProjects}
                  getOptionLabel={(option) => option.name}
                  value={values.musicalProjectIds}
                  onChange={(_, newValue) => {
                    setFieldValue("musicalProjectIds", newValue);
                    setFieldTouched("musicalProjectIds", true); // Set the touch status
                  }}
                  onBlur={() => setFieldTouched("musicalProjectIds", true)} // Ensure that field is marked touched on blur.
                  renderInput={(params) => (
                    <TextField
                      {...params}
                      variant="filled"
                      label="Select Projects"
                      error={
                        !!touched.musicalProjectIds &&
                        !!errors.musicalProjectIds
                      }
                      helperText={
                        touched.musicalProjectIds && errors.musicalProjectIds
                          ? errors.musicalProjectIds
                          : "\u00a0"
                      }
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
                <TextField
                  fullWidth
                  variant="filled"
                  type="text"
                  label="Location"
                  onBlur={handleBlur}
                  onChange={handleChange}
                  value={values.location}
                  name="location"
                  error={!!touched.location && !!errors.location}
                  helperText={
                    touched.location && errors.location
                      ? errors.location
                      : "\u00a0"
                  }
                  // Changes for increasing font size of label and helperText
                  InputLabelProps={{
                    style: { fontSize: "1rem" },
                    focused: false,
                  }} // Increase font size of label
                  FormHelperTextProps={{ style: { fontSize: "0.9rem" } }} // Increase font size of helperText
                />
              </Box>

              <div
                style={{
                  border: "1px solid #ccc",
                  borderRadius: "8px",
                  padding: "8px",
                  display: "inline-block",
                }}
              >
                <InputLabel htmlFor="coverImageFile">Cover Image</InputLabel>
                <Input
                  type="file"
                  id="coverImageFile"
                  name="coverImageFile"
                  onBlur={handleBlur}
                  onChange={(event) => {
                    setFieldValue(
                      "coverImageFile",
                      event.currentTarget.files[0]
                    );
                  }}
                  error={!!touched.coverImageFile && !!errors.coverImageFile}
                  inputProps={{ accept: "image/*" }}
                />
              </div>

              <FormControlLabel
                control={
                  <Checkbox
                    checked={values.generateTickets}
                    onChange={handleChange}
                    name="generateTickets"
                    color="default" // Use "default" color to apply custom color
                    sx={{ color: colors.blueAccent[400] }} // Custom color
                  />
                }
                label="Generate Tickets"
              />

              {values.generateTickets && (
                <Box className={styles.InputRow}>
                  <TextField
                    fullWidth
                    variant="filled"
                    type="number"
                    label="Number of Tickets"
                    onBlur={handleBlur}
                    onChange={handleChange}
                    value={values.numberOfTickets}
                    name="numberOfTickets"
                    error={
                      !!touched.numberOfTickets && !!errors.numberOfTickets
                    }
                    helperText={
                      touched.numberOfTickets && errors.numberOfTickets
                        ? errors.numberOfTickets
                        : "\u00a0"
                    }
                    InputLabelProps={{
                      style: { fontSize: "1rem" },
                      focused: false,
                    }}
                    FormHelperTextProps={{ style: { fontSize: "0.9rem" } }}
                  />

                  <TextField
                    fullWidth
                    variant="filled"
                    type="number"
                    label="Ticket Price"
                    onBlur={handleBlur}
                    onChange={handleChange}
                    value={values.ticketPrice}
                    name="ticketPrice"
                    error={!!touched.ticketPrice && !!errors.ticketPrice}
                    helperText={
                      touched.ticketPrice && errors.ticketPrice
                        ? errors.ticketPrice
                        : "\u00a0"
                    }
                    InputLabelProps={{
                      style: { fontSize: "1rem" },
                      focused: false,
                    }}
                    FormHelperTextProps={{ style: { fontSize: "0.9rem" } }}
                  />

                  <TextField
                    fullWidth
                    variant="filled"
                    select
                    label="Ticket Type"
                    onBlur={handleBlur}
                    onChange={handleChange}
                    value={values.ticketType}
                    name="ticketType"
                    error={!!touched.ticketType && !!errors.ticketType}
                    helperText={
                      touched.ticketType && errors.ticketType
                        ? errors.ticketType
                        : "\u00a0"
                    }
                    InputLabelProps={{
                      style: { fontSize: "1rem" },
                      focused: false,
                    }}
                    FormHelperTextProps={{ style: { fontSize: "0.9rem" } }}
                    SelectProps={{
                      MenuProps: {
                        PaperProps: {
                          style: {
                            backgroundColor: colors.blueAccent[700],
                          },
                        },
                      },
                    }}
                  >
                    {TICKET_TYPES.map((status) => (
                      <MenuItem key={status} value={status}>
                        {status}
                      </MenuItem>
                    ))}
                  </TextField>
                </Box>
              )}

              <Box className={styles.InputRow}>
                {/* Submit Button */}
                <Button
                  fullWidth
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
                  fullWidth
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
            </Box>
          </form>
        )}
      </Formik>
    </Box>
  );
}

export default EventsCreateForm;
