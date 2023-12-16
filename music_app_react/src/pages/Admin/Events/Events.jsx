import styles from "./Events.module.scss";
import { Box, Typography, useTheme } from "@mui/material";
import { DataGrid, GridToolbar } from "@mui/x-data-grid";
import { tokens } from "@/layouts/Admin/AdminTheme";
import Header from "@/components/Admin/Header/Header";
import { useState, useEffect } from "react";
import axiosInstance from "@/utils/axiosInstance";
import React from "react";
import { useNavigate } from "react-router-dom";
import adminRoutes from "@/routing/adminRoutes";
import { findPathByLabel } from "@/utils/routingUtils";
import IconButton from "@mui/material/IconButton";
import DeleteIcon from "@mui/icons-material/Delete";
import EditIcon from "@mui/icons-material/Edit";
import ViewIcon from "@mui/icons-material/Visibility";
import Button from "@mui/material/Button";
import { darken } from "@mui/system";
import Tooltip from "@/components/Global/UI/Tooltip";
import {
  EVENTS_GETALL_URL,
  EVENTS_DELETE_URL,
  BASE_WEB_URL,
} from "@/constants/Urls";
import DeleteModal from "@/components/Admin/Modals/DeleteModal/DeleteModal";
import { useSnackbar } from "notistack";
import moment from "moment";
import LinearProgress from "@mui/material/LinearProgress";

function Events() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const navigate = useNavigate();
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [eventIdToDelete, setEventIdToDelete] = useState(null);
  const { enqueueSnackbar } = useSnackbar();

  const handleAddEvent = () => {
    navigate(findPathByLabel(adminRoutes, "EventsCreate"));
  };

  const viewAction = (id) => {
    console.log("View action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "EventsDetails", { eventId: id }));
  };

  const editAction = (id) => {
    console.log("Edit action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "EventsUpdate", { eventId: id }));
  };

  const deleteAction = (id) => {
    setEventIdToDelete(id);
    setDeleteModalOpen(true);
  };

  const handleCloseDeleteModal = () => {
    setDeleteModalOpen(false);
    setEventIdToDelete(null); // Clear the selected eventIdToDelete
  };

  const handleDeleteEvent = () => {
    if (!eventIdToDelete) return; // Ensuring there's an event ID

    axiosInstance
      .delete(EVENTS_DELETE_URL(eventIdToDelete))
      .then((response) => {
        // Successful deletion: Remove the event from the 'data' state
        setData((prevData) =>
          prevData.filter((event) => event.id !== eventIdToDelete)
        );

        // Close the delete modal
        handleCloseDeleteModal();

        // Show a success notification to the user
        enqueueSnackbar("Event deleted successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
      })
      .catch((error) => {
        console.error("Error deleting the event: ", error);

        // Check if the error has a response from the server
        if (error.response) {
          if (error.response.status === 500) {
            // Internal server error: Navigate to the error500 page
            navigate("/error500");
          } else if (error.response.data && error.response.data.errors) {
            // Other server-side validation errors: Show them in Snackbars
            const errorsFromServer = error.response.data.errors;
            Object.values(errorsFromServer).forEach((errorArray) => {
              errorArray.forEach((singleError) => {
                enqueueSnackbar(singleError, {
                  variant: "error",
                  autoHideDuration: 5000,
                });
              });
            });
          }
        } else {
          // Other axios errors (e.g., network errors)
          enqueueSnackbar("Failed to delete the event. Please try again.", {
            variant: "error",
            autoHideDuration: 5000,
          });
        }
      });
  };

  const columns = [
    { field: "id", headerName: "ID", flex: 1 },
    { field: "title", headerName: "Title", width: 200 },
    {
      field: "eventDate",
      headerName: "Event Date",
      width: 130,
      renderCell: (params) => {
        return params.value
          ? moment(params.value).format("YYYY-MM-DD HH:mm")
          : "N/A";
      },
    },
    { field: "status", headerName: "Status", width: 100 },
    { field: "location", headerName: "Location", width: 100 },
    { field: "numberOfTickets", headerName: "Tickets Quantity", width: 150 },
    {
      field: "musicalProjectNames",
      headerName: "Projects",
      width: 100,
      renderCell: (params) => {
        // Convert the list of projects (which should be an array) to a sorted string
        const sortedProjects = [...params.value].sort(); // Sorting the array
        return sortedProjects.join("; ");
      },
    },
    {
      field: "coverImageUrl",
      headerName: "Cover Image",
      width: 180,
      cellClassName: styles.TableDataCell,
      renderCell: (params) => {
        const imageUrl = `${BASE_WEB_URL}/${params.value}`;
        return <img src={imageUrl} alt="Cover" width="150" height="150" />;
      },
    },
    {
      field: "actions",
      headerName: "Actions",
      headerAlign: "center",
      cellClassName: styles.TableDataCell,
      width: 120,
      renderCell: (params) => (
        <div>
          <Tooltip content="View Event">
            <IconButton
              onClick={() => viewAction(params.id)}
              color="secondary"
              aria-label="view"
            >
              <ViewIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Edit Event">
            <IconButton
              onClick={() => editAction(params.id)}
              color="secondary"
              aria-label="edit"
            >
              <EditIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Delete Event">
            <IconButton
              onClick={() => deleteAction(params.id)}
              color="secondary"
              aria-label="delete"
            >
              <DeleteIcon />
            </IconButton>
          </Tooltip>
        </div>
      ),
    },
  ];

  useEffect(() => {
    axiosInstance
      .get(EVENTS_GETALL_URL)
      .then((response) => {
        setData(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
        setLoading(false);
      });
  }, []);

  return (
    <Box m="20px">
      {/* HEADER */}
      <Box mb="5px">
        <Header title="Events" subtitle="The list of events!" />
        <Button
          variant="contained"
          sx={{
            width: "100%", // This makes the button span the full width
            backgroundColor: colors.blueAccent[500],
            "&:hover": {
              backgroundColor: darken(colors.blueAccent[600], 0.15),
            },
          }}
          onClick={handleAddEvent}
        >
          {" "}
          <Typography
            variant="h6"
            sx={{
              color:
                theme.palette.mode === "dark"
                  ? theme.palette.primary.contrastText
                  : theme.palette.secondary.contrastText,
              fontWeight: "bold",
            }}
          >
            Add New Event
          </Typography>
        </Button>
      </Box>
      <Box
        m="0 0 0 0"
        height="520px"
        sx={{
          "& .MuiDataGrid-root": {},
          "& .MuiDataGrid-cell": {
            fontSize: "0.9rem",
            borderRight: "2px solid rgba(0, 0, 0, 0.1)",
          },
          "& .MuiDataGrid-columnHeaders": {
            backgroundColor: colors.blueAccent[700],
            fontSize: "1rem",
          },
          "& .MuiDataGrid-columnHeader": {
            borderRight: "2px solid #003366",
          },
          "& .MuiDataGrid-columnHeaderTitle": {
            fontWeight: "bold",
          },
          "& .MuiDataGrid-virtualScroller": {
            backgroundColor: colors.primary[400],
          },
          "& .MuiDataGrid-footerContainer": {
            backgroundColor: colors.blueAccent[700],
          },
          "& .MuiDataGrid-toolbarContainer": {
            "& .MuiButton-root, & .MuiIconButton-root, & .MuiTypography-root": {
              color: colors.grey[100],
            },
          },
        }}
      >
        <DataGrid
          loading={loading}
          rowHeight={70}
          slots={{
            toolbar: GridToolbar,
            loadingOverlay: LinearProgress,
          }}
          slotProps={{
            toolbar: {
              showQuickFilter: true,
              quickFilterProps: { debounceMs: 500 },
            },
          }}
          rows={data}
          columns={columns}
          initialState={{
            pagination: {
              paginationModel: { pageSize: 10, page: 0 },
            },
          }}
          pageSizeOptions={[5, 10, 25, 100]}
        />
      </Box>
      <DeleteModal
        isOpen={deleteModalOpen}
        onClose={handleCloseDeleteModal}
        onDelete={handleDeleteEvent}
      />
    </Box>
  );
}

export default Events;
