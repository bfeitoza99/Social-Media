import { createRepost } from "@/services/post-service";
import { useUserStore } from "@/store/userStore";
import { useMutation, useQueryClient } from "@tanstack/react-query";
import { toast } from "react-hot-toast";

export function useCreateRepost() {
  const queryClient = useQueryClient();

  const { selectedUser } = useUserStore();

  return useMutation({
    mutationFn: async (originalPostId: number) => {
      if (!selectedUser) throw new Error("No user selected");
      return createRepost({ originalPostId, authorUserId: selectedUser.id });
    },
    onSuccess: () => {
      toast.dismiss("repost-success");
      toast.success("Your repost has been created!", { id: "repost-success" });
      queryClient.invalidateQueries({ queryKey: ["posts"] });
    },
    onError: (error: any) => {
      toast.dismiss("repost-error");
      const errorMessage = error?.response?.data?.message || error.message;
      toast.error(errorMessage, { id: "repost-error" });
    },
  });
}
