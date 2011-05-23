namespace InVision.Native
{
    public interface ICppInterface
    {
        /// <summary>
        /// Gets or sets the self.
        /// </summary>
        /// <value>The self.</value>
        Handle Self { get; set; }

		/// <summary>
		/// Sets the owner.
		/// </summary>
		/// <param name="owner">The owner.</param>
    	void SetOwner(object owner);
    }
}