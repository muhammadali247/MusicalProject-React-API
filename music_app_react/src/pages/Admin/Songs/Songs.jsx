import styles from "./Songs.module.scss";
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
import { SONGS_GETALL_URL, SONGS_DELETE_URL } from "@/constants/Urls";
import DeleteModal from "@/components/Admin/Modals/DeleteModal/DeleteModal";
import { useSnackbar } from "notistack";
import LinearProgress from "@mui/material/LinearProgress";

function Songs() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const navigate = useNavigate();
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [songIdToDelete, setSongIdToDelete] = useState(null);
  const { enqueueSnackbar } = useSnackbar();

  const handleAddSong = () => {
    navigate(findPathByLabel(adminRoutes, "SongsCreate"));
  };

  const viewAction = (id) => {
    console.log("View action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "SongsDetails", { songId: id }));
  };

  const editAction = (id) => {
    console.log("Edit action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "SongsUpdate", { songId: id }));
  };

  const deleteAction = (id) => {
    setSongIdToDelete(id);
    setDeleteModalOpen(true);
  };

  const handleCloseDeleteModal = () => {
    setDeleteModalOpen(false);
    setSongIdToDelete(null); // Clear the selected songIdToDelete
  };

  const handleDeleteSong = () => {
    if (!songIdToDelete) return; // Ensuring there's an song ID

    axiosInstance
      .delete(SONGS_DELETE_URL(songIdToDelete))
      .then((response) => {
        // Successful deletion: Remove the song from the 'data' state
        setData((prevData) =>
          prevData.filter((song) => song.id !== songIdToDelete)
        );

        // Close the delete modal
        handleCloseDeleteModal();

        // Show a success notification to the user
        enqueueSnackbar("Song deleted successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
      })
      .catch((error) => {
        console.error("Error deleting the song: ", error);

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
          enqueueSnackbar("Failed to delete the song. Please try again.", {
            variant: "error",
            autoHideDuration: 5000,
          });
        }
      });
  };

  const columns = [
    { field: "id", headerName: "ID", width: 90 },
    { field: "title", headerName: "Title", flex: 0.5 },
    {
      field: "durationInSeconds",
      headerName: "Duration",
      flex: 0.1,
      renderCell: (params) => {
        const mins = Math.floor(params.value / 60);
        const secs = params.value % 60;
        return `${mins}:${secs < 10 ? "0" : ""}${secs}`;
      },
    },
    { field: "trackOrderNumber", headerName: "Track Order", flex: 0.1 },
    { field: "albumTitle", headerName: "Album Title", flex: 0.2 },
    {
      field: "actions",
      headerName: "Actions",
      headerAlign: "center",
      width: 130,
      renderCell: (params) => (
        <div>
          <Tooltip content="View Song">
            <IconButton
              onClick={() => viewAction(params.id)}
              color="secondary"
              aria-label="view"
            >
              <ViewIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Edit Song">
            <IconButton
              onClick={() => editAction(params.id)}
              color="secondary"
              aria-label="edit"
            >
              <EditIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Delete Song">
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
      .get(SONGS_GETALL_URL)
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
        <Header title="Songs" subtitle="The list of songs!" />
        <Button
          variant="contained"
          sx={{
            width: "100%", // This makes the button span the full width
            backgroundColor: colors.blueAccent[500],
            "&:hover": {
              backgroundColor: darken(colors.blueAccent[600], 0.15),
            },
          }}
          onClick={handleAddSong}
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
            Add New Song
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
        onDelete={handleDeleteSong}
      />
    </Box>
  );
}

export default Songs;
