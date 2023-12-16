import styles from "./Tickets.module.scss";
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
  TICKETS_GETALL_URL,
  TICKETS_DELETE_URL,
  BASE_WEB_URL,
} from "@/constants/Urls";
import DeleteModal from "@/components/Admin/Modals/DeleteModal/DeleteModal";
import { useSnackbar } from "notistack";
import moment from "moment";
import LinearProgress from "@mui/material/LinearProgress";

function Tickets() {
  const [data, setData] = useState([]);
  const [loading, setLoading] = useState(true);
  const theme = useTheme();
  const colors = tokens(theme.palette.mode);
  const navigate = useNavigate();
  const [deleteModalOpen, setDeleteModalOpen] = useState(false);
  const [ticketIdToDelete, setTicketIdToDelete] = useState(null);
  const { enqueueSnackbar } = useSnackbar();

  const handleAddTicket = () => {
    navigate(findPathByLabel(adminRoutes, "TicketsCreate"));
  };

  const viewAction = (id) => {
    console.log("View action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "TicketsDetails", { ticketId: id }));
  };

  const editAction = (id) => {
    console.log("Edit action triggered for ID:", id);
    navigate(findPathByLabel(adminRoutes, "TicketsUpdate", { ticketId: id }));
  };

  const deleteAction = (id) => {
    setTicketIdToDelete(id);
    setDeleteModalOpen(true);
  };

  const handleCloseDeleteModal = () => {
    setDeleteModalOpen(false);
    setTicketIdToDelete(null); // Clear the selected ticketIdToDelete
  };

  const handleDeleteTicket = () => {
    if (!ticketIdToDelete) return; // Ensuring there's a ticket ID

    axiosInstance
      .delete(TICKETS_DELETE_URL(ticketIdToDelete))
      .then((response) => {
        // Successful deletion: Remove the ticket from the 'data' state
        setData((prevData) =>
          prevData.filter((ticket) => ticket.id !== ticketIdToDelete)
        );

        // Close the delete modal
        handleCloseDeleteModal();

        // Show a success notification to the user
        enqueueSnackbar("Ticket deleted successfully!", {
          variant: "success",
          autoHideDuration: 5000,
        });
      })
      .catch((error) => {
        console.error("Error deleting the ticket: ", error);

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
          enqueueSnackbar("Failed to delete the ticket. Please try again.", {
            variant: "error",
            autoHideDuration: 5000,
          });
        }
      });
  };

  const columns = [
    { field: "id", headerName: "ID", flex: 1 },
    { field: "price", headerName: "Price", width: 100 },
    {
      field: "purchaseDate",
      headerName: "Purchase Date",
      width: 130,
      renderCell: (params) => {
        return params.value
          ? moment(params.value).format("YYYY-MM-DD HH:mm")
          : "N/A";
      },
    },
    {
      field: "expirationDate",
      headerName: "Expiration Date",
      width: 130,
      renderCell: (params) => {
        return params.value
          ? moment(params.value).format("YYYY-MM-DD HH:mm")
          : "N/A";
      },
    },
    { field: "status", headerName: "Status", width: 100 },
    { field: "type", headerName: "Type", width: 100 },
    {
      field: "eventTitle",
      headerName: "Event Title",
      width: 300,
      renderCell: (params) => {
        return params.value || "N/A";
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
          <Tooltip content="View Ticket">
            <IconButton
              onClick={() => viewAction(params.id)}
              color="secondary"
              aria-label="view"
            >
              <ViewIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Edit Ticket">
            <IconButton
              onClick={() => editAction(params.id)}
              color="secondary"
              aria-label="edit"
            >
              <EditIcon />
            </IconButton>
          </Tooltip>
          <Tooltip content="Delete Ticket">
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
      .get(TICKETS_GETALL_URL)
      .then((response) => {
        setData(response.data);
        setLoading(false);
      })
      .catch((error) => {
        console.error("Error fetching data: ", error);
        setLoading(false);
      });
  }, []);

  return   <Box m="20px">
  {/* HEADER */}
  <Box mb="5px">
    <Header title="Tickets" subtitle="The list of tickets!" />
    <Button
      variant="contained"
      sx={{
        width: "100%", // This makes the button span the full width
        backgroundColor: colors.blueAccent[500],
        "&:hover": {
          backgroundColor: darken(colors.blueAccent[600], 0.15),
        },
      }}
      onClick={handleAddTicket}
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
        Add New Ticket
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
    onDelete={handleDeleteTicket}
  />
</Box>;
}

export default Tickets;
